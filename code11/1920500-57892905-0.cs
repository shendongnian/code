    private void button2_Click(object sender, EventArgs e)
        {
            //yes i commented them to solve why the file was not copying
            //try
            {
                FileInfo x = new FileInfo(textBox1.Text);
                x.CopyTo(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\some_location");
            }
            //catch
            { }
            this.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Title = "Select Image To Load";
            openDialog.Filter = "Text Files (*.png)|*.png" + "|" + "All Files (*.*)|*.*";
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                string PathData = openDialog.FileName;
                textBox1.Text = PathData;
            }
        }
