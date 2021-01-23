    public static byte[] GetBytes(string fileName)
    {
        byte[] buffer = new byte[4096];
        using (FileStream fs = new FileStream(fileName)) 
        using (MemoryStream ms = new MemoryStream())
        {
            fs.BlockCopy(ms, buffer, 4096); // extension method for the Stream class
            fs.Close();
            return ms.ToByteArray();
        }
    }
