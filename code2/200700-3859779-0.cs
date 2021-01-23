        private void button1_Click(object sender, EventArgs e)
        {
            System.Drawing.Bitmap bmp = new Bitmap("g.bmp");
            Clipboard.SetData(DataFormats.Bitmap, bmp);
            
            richTextBox1.Paste();
        }
