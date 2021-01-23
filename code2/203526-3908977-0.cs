	using(var sf = new StringFormat()
	{
		Alignment = StringAlignment.Center,
        LineAlignment = StringAlignment.Center,
	})
	{
		gra.DrawString(text, font, brush, new Rectangle(0, 0, bmp.Width, bmp.Height), sf);
	}
