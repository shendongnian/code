	var writeableBm1 = new WriteableBitmap(4, 3, 300, 300, 
		System.Windows.Media.PixelFormats.Bgr24, null);
	var w = writeableBm1.PixelWidth;
	var h = writeableBm1.PixelHeight;
	var stride = writeableBm1.BackBufferStride;
	var pixelPtr = writeableBm1.BackBuffer;
    // this is fast, changes to one object pixels will now be mirrored to the other 
	var bm2 = new Bitmap(w, h, stride, PixelFormat.Format24bppRgb, pixelPtr);
	writeableBm1.Lock();
	// you might wanna use this in combination with Lock / Unlock, AddDirtyRect, Freeze
	// before you write to the shared Ptr
	using (var g = Graphics.FromImage(bm2))
	{
		g.DrawString("MyText", new Font("Tahoma", 14), Brushes.White, 0, 0);
	}
	writeableBm1.Unlock();
