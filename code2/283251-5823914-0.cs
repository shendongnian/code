    Bitmap b = new Bitmap(myImage);
    BitmapData bd = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadOnly, ImageFormat.Format32Bpp);
    int arr[bd.Width * bd.Height - 1];
    Marshal.Copy(bd.Scan0, arr, 0, arr.Length);
    b.UnlockBits(bd);
