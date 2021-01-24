	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		pictureBox1.Invalidate();
	}
	private void trackBar1_Scroll(object sender, EventArgs e)
	{
		pictureBox1.Invalidate();
	}
	private void pictureBox1_Paint(object sender, PaintEventArgs e)
	{
		if (checkBox1.Checked)
		{
			int x, y;
			int w = pictureBox1.Size.Width;
			int h = pictureBox1.Size.Height;
			int inc = trackBar1.Value;
			Graphics gr = e.Graphics;
			if (checkBox1.Checked == true)
			{
				for (x = 0; x < w; x += inc)
					gr.DrawLine(Pens.Green, x, 0, x, h);
				for (y = 0; y < h; y += inc)
					gr.DrawLine(Pens.Green, 0, y, w, y);
			}
		}
	}
