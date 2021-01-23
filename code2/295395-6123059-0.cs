    private void button1_Click(object sender, EventArgs e)
    {
    	// Wrap the creation of the OpenFileDialog instance in a using statement,
    	// rather than manually calling the Dispose method to ensure proper disposal
    	using (OpenFileDialog dlg = new OpenFileDialog())
        {
            dlg.Title = "Open Image";
            dlg.Filter = "bmp files (*.bmp)|*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                PictureBox PictureBox1 = new PictureBox();
                
                // Create a new Bitmap object from the picture file on disk,
                // and assign that to the PictureBox.Image property
                PictureBox1.Image = new Bitmap(dlg.FileName);
            }
        }
    }
    
