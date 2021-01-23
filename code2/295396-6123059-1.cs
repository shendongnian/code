    private void button1_Click(object sender, EventArgs e)
    {
    	using (OpenFileDialog dlg = new OpenFileDialog())
        {
            dlg.Title = "Open Image";
            dlg.Filter = "bmp files (*.bmp)|*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                PictureBox PictureBox1 = new PictureBox();
                PictureBox1.Image = new Bitmap(dlg.FileName);
                // Add the new control to its parent's controls collection
                this.Controls.Add(PictureBox1);
            }
        }
    }
