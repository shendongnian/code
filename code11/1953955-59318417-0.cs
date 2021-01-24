	RenderTargetBitmap bitmap =
	new RenderTargetBitmap((int)el.ActualWidth, (int)el.ActualHeight, 96, 96, PixelFormats.Pbgra32);
	bitmap.Render(el);
	using (FileStream stream = File.Create(@"label.png"))
	{
		PngBitmapEncoder encoder = new PngBitmapEncoder();
		encoder.Frames.Add(BitmapFrame.Create(bitmap));
		encoder.Save(stream);
	}
}
~~~
