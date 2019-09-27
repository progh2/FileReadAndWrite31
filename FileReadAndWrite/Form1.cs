using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FileReadAndWrite
{
    public partial class FormFile : Form
    {
        public FormFile()
        {
            InitializeComponent();
        }

        private void BtnReadFileSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDlg.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    this.txtReadFile.Text = this.openFileDlg.FileName;
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("파일 선택을 취소하였습니다", "알림");
                    break;
            }
        }

        private void BtnReadText_Click(object sender, EventArgs e)
        {
            if(txtReadFile.Text == "") {
                MessageBox.Show("파일을 선택해 주세요!", "에러",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!File.Exists(txtReadFile.Text))
            {
                MessageBox.Show("파일을 열 수 없습니다!", "에러",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (StreamReader sr = new StreamReader(txtReadFile.Text))
            {
                this.txtReadText.Text = sr.ReadToEnd();
            }
        }

        private void BtnWriteFileSelect_Click(object sender, EventArgs e)
        {
            DialogResult result = this.saveFileDlg.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    this.txtWriteFile.Text = this.saveFileDlg.FileName;
                    break;
                case DialogResult.Cancel:
                    MessageBox.Show("파일 선택을 취소하였습니다", "알림");
                    break;
            }
        }

        private void BtnWriteText_Click(object sender, EventArgs e)
        {
            if (this.txtWriteFile.Text == "")
            {
                MessageBox.Show("파일을 선택해 주세요!", "에러",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(this.txtWriteFile.Text))
                {
                    sw.WriteLine(this.txtWriteText.Text);
                }
                MessageBox.Show("저장 성공", "알림");
            }
            catch
            {
                MessageBox.Show("파일을 저장할 수 없었습니다!", "에러",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
