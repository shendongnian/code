    public byte[] imageToByteArray(System.Drawing.Image imageIn)
    {
       using (var ms = new MemoryStream())
       {
          imageIn.Save(ms,System.Drawing.Imaging.ImageFormat.Gif);
          return  ms.ToArray();
       }
    }
