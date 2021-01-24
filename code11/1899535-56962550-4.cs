    public static string SetSignature(string imageData)
	{
        string filePath = HttpContext.Current.Server.MapPath("Signature.png");
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                byte[] data = Convert.FromBase64String(imageData);
                bw.Write(data);
                bw.Close();
            }
        }
    }
