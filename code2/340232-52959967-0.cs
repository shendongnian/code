            public static void CreateWpfImage()
            {
                int imageWidth = 100;
                int imageHeight = 100;
                string outputFile = "C:/Users/Krythic/Desktop/Test.png";
                // Create the Rectangle
                DrawingVisual visual = new DrawingVisual();
                DrawingContext context = visual.RenderOpen();
                context.DrawRectangle(Brushes.Red, null, new Rect(20,20,32,32));
                context.Close();
    
                // Create the Bitmap and render the rectangle onto it.
                RenderTargetBitmap bmp = new RenderTargetBitmap(imageWidth, imageHeight, 96, 96, PixelFormats.Pbgra32);
                bmp.Render(visual);
    
                // Save the image to a location on the disk.
                PngBitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bmp));
                encoder.Save(new FileStream(outputFile, FileMode.Create));
            }
