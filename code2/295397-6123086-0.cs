    private void button1_Click(object sender, EventArgs e)
    {
        OpenFileDialog dlg = new OpenFileDialog();
        dlg.Title = "Open Image";
        dlg.Filter = "bmp files (*.bmp)|*.bmp";
        if (dlg.ShowDialog() == DialogResult.OK)
        {                     
            PictureBox1.Image = Image.FromFile(dlg.Filename);
        }
        dlg.Dispose();
    }
