	var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height),
		System.Drawing.Imaging.ImageLockMode.ReadOnly,
		System.Drawing.Imaging.PixelFormat.Format32bppArgb);
	Marshal.Copy(data.Scan0, array, 0, data.Stride * data.Height);
	bmp.UnlockBits(data);
