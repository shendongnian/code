	void ReplaceResizedPictureBoxImage(Bitmap bmp)
	{
		var oldBitmap = pictureBox.Image;
		var bmp2 = new Bitmap(pictureBox.Width, pictureBox.Height);
		using (var g = Graphics.FromImage(bmp2))
		{
			g.InterpolationMode = InterpolationMode.NearestNeighbor;
			g.DrawImage(bmp, new Rectangle(Point.Empty, bmp2.Size));
			pictureBox.Image = bmp2;
		}
        if (oldBitmap != null)
            oldBitmap.Dispose();
	}
