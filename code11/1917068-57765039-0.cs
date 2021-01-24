    private byte[] ConvertMediaFileToByteArray(MediaFile file)
    {
         using (var memoryStream = new MemoryStream())
         {
              file.GetStream().CopyTo(memoryStream);
              return memoryStream.ToArray();
         }
     }
