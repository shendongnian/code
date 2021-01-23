    public static class Rbex
    {
        public static Bitmap ToBitmap(this RenderBuffer buffer)
        {
            const int depth = 4; 
            const PixelFormat pf = PixelFormat.Format32bppArgb;
	        // Create bitmap
	        Bitmap bitmap = new Bitmap(buffer.GetWidth(), buffer.GetHeight(), pf);
	        BitmapData data = bitmap.LockBits(new Rectangle(0,0, buffer.GetWidth(), buffer.GetHeight()), ImageLockMode.WriteOnly, bitmap.PixelFormat);
	        buffer.CopyTo(data.Scan0, buffer.GetWidth() * depth, depth, false);
	        bitmap.UnlockBits(data);
	        return bitmap;
        }
    }
