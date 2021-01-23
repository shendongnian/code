    private void button1_Click(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    return;
                }
                string extention = Path.GetExtension(textBox1.Text);
                string fileName = Path.GetFileNameWithoutExtension(textBox1.Text);
    
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = String.Format("{0} files | *{0}", extention);
                saveFileDialog.FileName = fileName;
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    WebClient client = new WebClient();
                    client.DownloadFile(textBox1.Text, saveFileDialog.FileName);
                }
            }
