     public void ConvertCanvasToBitmap_second(Canvas surface)
        {
            //mycanvas.Background = new SolidColorBrush(Colors.White);
            RenderTargetBitmap [] renderTargetBitmaps = new RenderTargetBitmap [2];
            Label lblPagination = new Label
            {
                Name = "lblPagination",
                FontSize = 6
            };
            surface.Children.Add(lblPagination);
            Canvas.SetRight(lblPagination, 0);
            Canvas.SetBottom(lblPagination, 0);
            // Get the size of canvas
            System.Windows.Size size = new System.Windows.Size(surface.Width, surface.Height);
            // Measure and arrange the surface
            // VERY IMPORTANT
            surface.Measure(size);
            surface.Arrange(new Rect(size));
            for (int i = 0; i < 2; i++)
            {
                lblPagination.Content = (i + 1).ToString();
                // Create a render bitmap and push the surface to it
                RenderTargetBitmap renderBitmap =
                  new RenderTargetBitmap(
                    (int)size.Width,
                    (int)size.Height,
                    96d,
                    96d,
                    PixelFormats.Pbgra32);
                renderBitmap.Render(surface);
           
                renderTargetBitmaps[i] = renderBitmap;
            }
    
    
            for (int i = 0; i < renderTargetBitmaps.Length; i++)
            {
                var vis = new DrawingVisual();
                using (var dc = vis.RenderOpen())
                {
                    dc.DrawImage(renderTargetBitmaps[i], new Rect(0, 0, (int)size.Width, (int)size.Height));
                }
   
                PrintDialog printDlg = new PrintDialog();
                printDlg.PrintVisual(vis, "Label Printing.");
            }
        }
