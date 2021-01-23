	using System.IO; // namespace for  using MemoryStream
	
	private static byte[] ReadImageMemory()
	{
		BitmapSource bitmapSource = BitmapConversion.ToBitmapSource(Clipboard.GetImage());
        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        MemoryStream memoryStream = new MemoryStream();
        encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
        encoder.Save(memoryStream);
        return memoryStream.GetBuffer();
    }
    // and calling by this example........
    byte[] buffer = ReadImageMemory();
