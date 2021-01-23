    public static System.Drawing.Image ByteArrayToImage(byte[] bArray)
    {
        if (bArray == null)
            return null;
        System.Drawing.Image newImage;
        try
        {
            using (MemoryStream ms = new MemoryStream(bArray, 0, bArray.Length))
            {
                ms.Write(bArray, 0, bArray.Length);
                newImage = System.Drawing.Image.FromStream(ms, true);
            }
        }
        catch (Exception ex)
        {
            newImage = null;
            //Log an error here
        }
        return newImage;
    }
