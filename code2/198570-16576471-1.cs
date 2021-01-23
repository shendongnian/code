      /// <summary>
      /// Method that uses the ImageConverter object in .Net Framework to convert a byte array, 
      /// presumably containing a JPEG or PNG file image, into a Bitmap object, which can also be 
      /// used as an Image object.
      /// </summary>
      /// <param name="byteArray">byte array containing JPEG or PNG file image or similar</param>
      /// <returns>Bitmap object if it works, else exception is thrown</returns>
      public static Bitmap GetImageFromByteArray(byte[] byteArray)
      {
         Bitmap bm = (Bitmap)_imageConverter.ConvertFrom(byteArray);
         
         if (bm != null)
         {
            // Correct a strange glitch that has been observed in the test program when converting 
            //  from a PNG file image created by CopyImageToByteArray()
            if (bm.HorizontalResolution < 96 && bm.HorizontalResolution > 95.98 &&
                bm.VerticalResolution < 96 && bm.VerticalResolution > 95.98)
            bm.SetResolution(96, 96);
         }
         return bm;
      }
