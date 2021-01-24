    //Convert Stream to bytes array  
    public static byte[] ReadAsBytes(Stream input)
    {
        using (var ms = new MemoryStream())
        {
            input.CopyTo(ms);
            return ms.ToArray();
        }
    }
