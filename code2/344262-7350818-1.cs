    public static byte[] ImageToByte2(Image img)
    {
        byte[] byteArray = new byte[0];
        using (MemoryStream stream = new MemoryStream())
        {
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Close();
    
            byteArray = stream.ToArray();
        }
        return byteArray;
    }
