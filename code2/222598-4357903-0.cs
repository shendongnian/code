        byte[] ConvertTo8bpp(Bitmap sourceBitmap)
        {
            // generate a custom palette for the bitmap (I already had a list of colors
            // from a previous operation
            Dictionary<System.Drawing.Color, byte> colorDict = new Dictionary<System.Drawing.Color, byte>(); // lookup table for conversion to indexed color
            List<System.Windows.Media.Color> colorList = new List<System.Windows.Media.Color>(); // list for palette creation
            byte index = 0;
            unchecked
            {
                foreach (var cc in ColorsFromPreviousOperation)
                {
                    colorDict[cc] = index++;
                    colorList.Add(cc.ToMediaColor());
                }
            }
            System.Windows.Media.Imaging.BitmapPalette bmpPal = new System.Windows.Media.Imaging.BitmapPalette(colorList);
            // create the byte array of raw image data
            int width = sourceBitmap.Width;
            int height = sourceBitmap.Height;
            int stride = sourceBitmap.Width;
            byte[] imageData = new byte[width * height];
            for (int x = 0; x < width; ++x)
                for (int y = 0; y < height; ++y)
                {
                    var pixelColor = sourceBitmap.GetPixel(x, y);
                    imageData[x + (stride * y)] = colorDict[pixelColor];
                }
            // generate the image source
            var bsource = BitmapSource.Create(width, height, 96, 96, PixelFormats.Indexed8, bmpPal, imageData, stride);
            // encode the image
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Interlace = PngInterlaceOption.Off;
            encoder.Frames.Add(BitmapFrame.Create(bsource));
            MemoryStream outputStream = new MemoryStream();
            encoder.Save(outputStream);
            return outputStream.ToArray();
        }
