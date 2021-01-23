       Visual theVisual = textBlock ; //Put the aimed visual here.
       double width = Convert.ToDouble(theVisual.GetValue(FrameworkElement.WidthProperty));
       double height = Convert.ToDouble(
                           theVisual.GetValue(FrameworkElement.HeightProperty));
       if (double.IsNaN(width) || double.IsNaN(height))
       {
           throw new  FormatException(
              "You need to indicate the Width and Height values of the UIElement.");
       }
       RenderTargetBitmap render = new  RenderTargetBitmap(
              Convert.ToInt32(width),
              Convert.ToInt32(this.GetValue(FrameworkElement.HeightProperty)),
              96,
              96,
              PixelFormats.Pbgra32);
       // Indicate which control to render in the image
       render.Render(this);
       Stream oStream = new  MemoryStream();
       PngBitmapEncoder encoder = new  PngBitmapEncoder();
       encoder.Frames.Add(BitmapFrame.Create(render));
       encoder.Save(oStream);
       oStream.Flush();
