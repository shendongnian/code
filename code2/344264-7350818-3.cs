    public static byte[] ImageToByte2(Image img)
    {
        byte[] byteArray = new byte[0];
        using (var stream = new MemoryStream())
        {
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
    
            byteArray = stream.ToArray();
        }
        return byteArray;
    }
