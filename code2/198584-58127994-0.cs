    public byte[] ImageToByteArray(System.Drawing.Image images)
    {
       using (var _memorystream = new MemoryStream())
       {
          images.Save(_memorystream ,images.RawFormat);
          return  _memorystream .ToArray();
       }
    }
