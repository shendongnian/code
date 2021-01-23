    Bitmap image = new Bitmap(pictureBox3.Width, pictureBox3.Height);
    SolidBrush brush = new SolidBrush(Color.Empty);
    using (Graphics g = Graphics.FromImage(image))
    {
    	for (int x = 0; x < image.Width; x++)
    	{
    		for (int y = 0; y < image.Height; y++)
    		{
    			brush.Color = Color.FromArgb(x, y, 0);
    			g.FillRectangle(brush, x, y, 1, 1);
    		}
    	}
    }
    pictureBox3.Image = image;
