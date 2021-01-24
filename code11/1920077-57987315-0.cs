        // needs System.Windows.Media & System.Windows.Media.Imaging (PresentationCore & WindowsBase)
        public static void SaveThumbnail(string absoluteFilePath, int thumbnailSize)
        {
            if (absoluteFilePath == null)
                throw new ArgumentNullException(absoluteFilePath);
            var bitmap = BitmapDecoder.Create(new Uri(absoluteFilePath), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.None).Frames[0];
            int width;
            int height;
            if (bitmap.Width > bitmap.Height)
            {
                width = thumbnailSize;
                height = (int)(bitmap.Height * thumbnailSize / bitmap.Width);
            }
            else
            {
                width = (int)(bitmap.Width * thumbnailSize / bitmap.Height);
                height = thumbnailSize;
            }
            var resized = BitmapFrame.Create(new TransformedBitmap(bitmap, new ScaleTransform(width / bitmap.Width * 96 / bitmap.DpiX, height / bitmap.Height * 96 / bitmap.DpiY, 0, 0)));
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(resized);
            var thumbnailFilePath = Path.ChangeExtension(absoluteFilePath, thumbnailSize + Path.GetExtension(absoluteFilePath));
            using (var stream = File.OpenWrite(thumbnailFilePath))
            {
                encoder.Save(stream);
            }
        }
