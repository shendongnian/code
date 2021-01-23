         private static void SaveUsingEncoder(string fileName, FrameworkElement UIElement, BitmapEncoder encoder)
        {
            int height = (int)UIElement.ActualHeight;
            int width = (int)UIElement.ActualWidth;
            // These two line of code make sure that you get completed visual bitmap.
            // In case your Framework Element is inside the scroll viewer then some part which is not
            // visible gets clip.  
            UIElement.Measure(new System.Windows.Size(width, height));
            UIElement.Arrange(new Rect(new System.Windows.Point(), new Point(width, height)));
            RenderTargetBitmap bitmap = new RenderTargetBitmap(width,
                                                                    height,
                                                                    96, // These decides the dpi factors 
                                                                    96,// The can be changed when we'll have preview options.
                                                                    PixelFormats.Pbgra32);
            bitmap.Render(UIElement);
            SaveUsingBitmapTargetRenderer(fileName, bitmap, encoder);
        }
         private static void SaveUsingBitmapTargetRenderer(string fileName, RenderTargetBitmap renderTargetBitmap, BitmapEncoder bitmapEncoder)
        {
            BitmapFrame frame = BitmapFrame.Create(renderTargetBitmap);
            bitmapEncoder.Frames.Add(frame);
            // Save file .
            using (var stream = File.Create(fileName))
            {
                bitmapEncoder.Save(stream);
            }
        }
