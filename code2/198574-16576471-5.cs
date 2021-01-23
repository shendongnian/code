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
         
         if (bm != null && (bm.HorizontalResolution != (int)bm.HorizontalResolution ||
                            bm.VerticalResolution != (int)bm.VerticalResolution))
         {
            // Correct a strange glitch that has been observed in the test program when converting 
            //  from a PNG file image created by CopyImageToByteArray() - the dpi value "drifts" 
            //  slightly away from the nominal integer value
            bm.SetResolution((int)(bm.HorizontalResolution + 0.5f), 
                             (int)(bm.VerticalResolution + 0.5f));
         }
         return bm;
      }
