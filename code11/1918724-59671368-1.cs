    //var img = Dlib.LoadImage<RgbPixel>(inputFilePath);
	Bitmap bitmap = (Bitmap)Bitmap.FromFile(inputFilePath);
	System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height);
	System.Drawing.Imaging.BitmapData data = bitmap.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);
	var array = new byte[data.Stride * data.Height];
	Marshal.Copy(data.Scan0, array, 0, array.Length);
	Array2D<BgrPixel> img = Dlib.LoadImageData<BgrPixel>(array, (uint)bitmap.Height, (uint)bitmap.Width, (uint)data.Stride);
