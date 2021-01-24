	var writeableBm1 = new WriteableBitmap(200, 100, 96, 96, 
		System.Windows.Media.PixelFormats.Bgr24, null);
	var w = writeableBm1.PixelWidth;
	var h = writeableBm1.PixelHeight;
	var stride = writeableBm1.BackBufferStride;
	var pixelPtr = writeableBm1.BackBuffer;
    // this is fast, changes to one object pixels will now be mirrored to the other 
	var bm2 = new System.Drawing.Bitmap(
        w, h, stride, System.Drawing.Imaging.PixelFormat.Format24bppRgb, pixelPtr);
	writeableBm1.Lock();
	// you might wanna use this in combination with Lock / Unlock, AddDirtyRect, Freeze
	// before you write to the shared Ptr
	using (var g = System.Drawing.Graphics.FromImage(bm2))
	{
		g.DrawString("MyText", new Font("Tahoma", 14), System.Drawing.Brushes.White, 0, 0);
	}
    writeableBm1.AddDirtyRect(new Int32Rect(0, 0, 200, 100));
	writeableBm1.Unlock();
