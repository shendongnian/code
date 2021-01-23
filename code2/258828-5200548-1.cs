		string newImagePath = "your file path";
		var ms = new MemoryStream();             
		using (FileStream fs = new FileStream(newImagePath , FileMode.Create)
		{
			var rtb = new RenderTargetBitmap((int)inkImageCanvas.Width, (int)inkImageCanvas.Height, 96d, 96d, PixelFormats.Default);             
			rtb.Render(inkImageCanvas);             
			JpegBitmapEncoder encoder = new JpegBitmapEncoder();             
			encoder.Frames.Add(BitmapFrame.Create(rtb));              
			encoder.Save(fs);             
		}
