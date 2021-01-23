        public void MakeThumbnail(string imagePath)
        {
            // Image exists?
            if (string.IsNullOrEmpty(imagePath)) throw new FileNotFoundException("Image does not exist at " + imagePath);
            // Default values
            string Filename = imagePath.ToLower().Replace(".jpg", "_thumb.jpg");
            int Width = 100; // 180;
            int Height = 75; // 135;
            bool lSaved = false;
            // Load image
            Bitmap bitmap = new Bitmap(imagePath);
            // If image is smaller than just save
            try
            {
                if (bitmap.Width <= Width && bitmap.Height <= Height)
                {
                    bitmap.Save(Filename, ImageFormat.Jpeg);
                    lSaved = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                bitmap.Dispose();
            }
            if (!lSaved)
            {
                Bitmap FinalBitmap = null;
                // Making Thumb
                try
                {
                    bitmap = new Bitmap(imagePath);
                    int BitmapNewWidth;
                    decimal Ratio;
                    int BitmapNewHeight;
                    // Change size of image
                    Ratio = (decimal)Width / Height;
                    BitmapNewWidth = Width;
                    BitmapNewHeight = Height;
                    // Image processing
                    FinalBitmap = new Bitmap(BitmapNewWidth, BitmapNewHeight);
                    Graphics graphics = Graphics.FromImage(FinalBitmap);
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.FillRectangle(Brushes.White, 0, 0, BitmapNewWidth, BitmapNewHeight);
                    graphics.DrawImage(bitmap, 0, 0, BitmapNewWidth, BitmapNewHeight);
                    // Save modified image
                    FinalBitmap.Save(Filename, ImageFormat.Jpeg);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    if (FinalBitmap != null) FinalBitmap.Dispose();
                }
            }
        }
