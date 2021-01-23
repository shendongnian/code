        public static Stream ResizeGdi(Stream stream, System.Drawing.Size size)
        {
            Image image = Image.FromStream(stream);
            int width = image.Width;
            int height = image.Height;
            int sourceX = 0, sourceY = 0, destX = 0, destY = 0;
            float percent = 0, percentWidth = 0, percentHeight = 0;
            percentWidth = ((float)size.Width / (float)width);
            percentHeight = ((float)size.Height / (float)height);
            int destW = 0;
            int destH = 0;
            if (percentHeight < percentWidth)
            {
                percent = percentHeight;
            }
            else
            {
                percent = percentWidth;
            }
            destW = (int)(width * percent);
            destH = (int)(height * percent);
            MemoryStream mStream = new MemoryStream();
            if (destW == 0
                && destH == 0)
            {
                image.Save(mStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                return mStream;
            }
            using (Bitmap bitmap = new Bitmap(destW, destH, System.Drawing.Imaging.PixelFormat.Format48bppRgb))
            {
                using (System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(bitmap))
                {
                    //graphics.Clear(Color.Red);
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphics.DrawImage(image,
                        new Rectangle(destX, destY, destW, destH),
                        new Rectangle(sourceX, sourceY, width, height),
                        GraphicsUnit.Pixel);
                }
                bitmap.Save(mStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            mStream.Position = 0;
            return mStream as Stream;
        }
