    public byte[] convertImageToByteArray(System.Drawing.Image image)
    {
         using (MemoryStream ms = new MemoryStream())
         {
             image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif); 
                 // or whatever output format you like
             return ms.ToArray(); 
         }
    }
