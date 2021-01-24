            private System.Drawing.Image ResizeImage(System.Drawing.Image image, int size)
            {
                System.Drawing.Image resizedImage = new Bitmap(size, size);
    
                using (Graphics graphicsHandler = Graphics.FromImage(resizedImage))
                {
                    graphicsHandler.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphicsHandler.DrawImage(image, 0, 0, size, size);
                }
    
                return resizedImage;
            }
