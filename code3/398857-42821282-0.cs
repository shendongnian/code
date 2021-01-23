     FileStream streamObj = System.IO.File.OpenRead(@"C:\Files\Photo.jpg");
Byte[] newImage=UploadFoto(streamObj); 
     
      public static Byte[] UploadFoto(FileStream fileUpload)
            {
                Byte[] imgByte = null;
                imgByte = lnkUpload(fileUpload);
                return imgByte;
            }
            
            
             private static Byte[] lnkUpload(FileStream img)
            {
                byte[] resizedImage;
                using (Image orginalImage = Image.FromStream(img))
                {
                    ImageFormat orginalImageFormat = orginalImage.RawFormat;
                    int orginalImageWidth = orginalImage.Width;
                    int orginalImageHeight = orginalImage.Height;
                    int resizedImageWidth = 60; // Type here the width you want
                    int resizedImageHeight = Convert.ToInt32(resizedImageWidth * orginalImageHeight / orginalImageWidth);
                    using (Bitmap bitmapResized = new Bitmap(orginalImage, resizedImageWidth, resizedImageHeight))
                    {
                        using (MemoryStream streamResized = new MemoryStream())
                        {
                            bitmapResized.Save(streamResized, orginalImageFormat);
                            resizedImage = streamResized.ToArray();
                        }
                    }
                }
                return resizedImage;
            }
