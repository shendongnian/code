        private void Form1_Load(object sender, EventArgs e)
        {
            const string path = @"D:\RichTextBox\Example.txt";
            if (File.Exists(path))
            {
                richTextBox1.Rtf = System.IO.File.ReadAllText(path);
            }
        }
