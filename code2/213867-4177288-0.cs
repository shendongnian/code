    using (Graphics g = Graphics.FromImage(pictureBox1.Image))
    {
    	g.DrawImage(pictureBox2.Image, 
    		(int)((pictureBox1.Image.Width - pictureBox2.Image.Width) / 2),
    		(int)((pictureBox1.Image.Height - pictureBox2.Image.Height) / 2));
    	g.Save();
    	pictureBox1.Refresh();
    }
