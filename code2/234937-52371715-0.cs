        public void to4bit(Bitmap sourceBitmap, Stream outputStream)
        {
            BitmapImage myBitmapImage = ToBitmapImage(sourceBitmap);
            FormatConvertedBitmap fcb = new FormatConvertedBitmap();
            fcb.BeginInit();
            myBitmapImage.DecodePixelWidth = sourceBitmap.Width;
            fcb.Source = myBitmapImage;
            fcb.DestinationFormat = System.Windows.Media.PixelFormats.Gray4;
            fcb.EndInit();
            PngBitmapEncoder bme = new PngBitmapEncoder();
            bme.Frames.Add(BitmapFrame.Create(fcb));
            bme.Save(outputStream);
        }
        private BitmapImage ToBitmapImage(Bitmap sourceBitmap)
        {
            using (var memory = new MemoryStream())
            {
                sourceBitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
