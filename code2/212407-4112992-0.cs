	public static byte GetIndexedPixel(this Bitmap bitmap, int x, int y)
	{
		var bd = bitmap.LockBits(new Rectangle(x, y, 1, 1),
			System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
		var color = System.Runtime.InteropServices.Marshal.ReadByte(bd.Scan0);
		bitmap.UnlockBits(bd);
		return color;
	}
	public static void SetIndexedPixel(this Bitmap bitmap, int x, int y, byte color)
	{
		var bd = bitmap.LockBits(new Rectangle(x, y, 1, 1),
			System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
		System.Runtime.InteropServices.Marshal.WriteByte(bd.Scan0, color);
		bitmap.UnlockBits(bd);
	}
