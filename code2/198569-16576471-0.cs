      /// <summary>
      /// Method to "convert" an Image object into a byte array, formatted in PNG file format, which 
      /// provides lossless compression. The can be used together with the GetImageFromByteArray() 
      /// method to provide a kind of serialization / deserialization. 
      /// </summary>
      /// <param name="theImage">Image object, must be convertable to PNG format</param>
      /// <returns>byte array image of a PNG file containing the image</returns>
      public static byte[] CopyImageToByteArray(Image theImage)
      {
         using (MemoryStream memoryStream = new MemoryStream())
         {
            theImage.Save(memoryStream, ImageFormat.Png);
            return memoryStream.ToArray();
         }
      }
