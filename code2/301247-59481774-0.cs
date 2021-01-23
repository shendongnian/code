    public static string BitmapToBase64(Bitmap b)
    {
       ImageConverter ic = new ImageConverter();
       byte[] ba = (byte[])ic.ConvertTo(b, typeof(byte[]));
       return Convert.ToBase64String(ba, 0, ba.Length);
    }
