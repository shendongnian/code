        public Image Thumbnail(Image FullsizeImage, int MaxHeight, int MaxWidth)
        {
          
            try
            {
                // This has to be here or for some reason this resize code will
                // resize an internal Thumbnail and wil stretch it instead of shrinking
                // the fullsized image and give horrible results
                FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
                FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
                System.Drawing.Image NewImage;
                if (!((MaxWidth < FullsizeImage.Width) || (MaxHeight < FullsizeImage.Height)))
                    NewImage = FullsizeImage;
                else
                {
                    float HeightRatio = 1;
                    float WidthRatio = 1;
                    HeightRatio = (float)FullsizeImage.Width / FullsizeImage.Height;
                    WidthRatio = (float)FullsizeImage.Height / FullsizeImage.Width;
                    float DrawHeight = (float)FullsizeImage.Height;
                    float DrawWidth = (float)FullsizeImage.Width;
                    if (MaxHeight < FullsizeImage.Height)
                    {
                        DrawHeight = (float)MaxHeight;
                        DrawWidth = MaxHeight * HeightRatio;
                    }
                    if (MaxWidth < DrawWidth)
                    {
                        DrawWidth = MaxWidth;
                        DrawHeight = DrawWidth * WidthRatio;
                    }
                    NewImage = FullsizeImage.GetThumbnailImage((int)(DrawWidth),
                           (int)(DrawHeight), null, IntPtr.Zero);
                }
                return NewImage;
                // To return a byte array for saving in a db 
                //ms = new MemoryStream();
                //NewImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                //NewImage.Dispose();
                //FullsizeImage.Dispose();
                //return ms.ToArray();
            }
            catch
            {
                return null;
            }
            finally
            {
             
            }
        }
        public Image Resize(Image OrigImage, int NewHeight, int NewWidth)
        {
            if (OrigImage != null)
            {                
                Bitmap bmp = new Bitmap(OrigImage, new Size(NewWidth, NewHeight));
                bmp.SetResolution(this.ImageResolution, this.ImageResolution);
                Graphics g = Graphics.FromImage(bmp);
                return bmp;
            }
            else
            {
                return null;
            }
        }
