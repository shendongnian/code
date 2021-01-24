    public static string Image2Base64(string xPath)
    {
        //PNG TO BASE64         
        byte[] bytes = File.ReadAllBytes(xPath); //READ BYTES
        if (bytes == null) return null;
    
        //CONVERT BASE64
        return Convert.ToBase64String(bytes);
    }
