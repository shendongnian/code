    RenderTargetBitmap rtb = new RenderTargetBitmap(width, height, mXdpi, mYdpi, System.Windows.Media.PixelFormats.Default);
            rtb.Render(my_canvas);
            BitmapEncoder pngEncoder = new PngBitmapEncoder();
            pngEncoder.Frames.Add(BitmapFrame.Create(rtb));
            using (var fs = System.IO.File.OpenWrite("test.png"))
            {
                pngEncoder.Save(fs);
            }
