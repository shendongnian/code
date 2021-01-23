          Rect bounds = VisualTreeHelper.GetDescendantBounds(FrontCanvas);
          double dpiX =e.Graphics.DpiX  , dpiY=e.Graphics.DpiY ;
          RenderTargetBitmap rtb = new RenderTargetBitmap((int)(bounds.Width * dpiX  / 96.0),
                                                          (int)(bounds.Height * dpiY   / 96.0),
                                                          dpiX,
                                                          dpiY,
                                                          PixelFormats.Pbgra32);
          DrawingVisual dv = new DrawingVisual();
          using (DrawingContext ctx = dv.RenderOpen())
          {
              VisualBrush vb = new VisualBrush(FrontCanvas);
              ctx.DrawRectangle(vb, null, new Rect(new Point(), bounds.Size));
          }
          rtb.Render(dv);
          //System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(rtb);
          //e.Graphics.DrawImage(rtb, 0, 0);
          using (MemoryStream outStream = new MemoryStream())
          {
              // Use png encoder for  data
              BitmapEncoder encoder = new PngBitmapEncoder();
              // push the rendered bitmap to it
              encoder.Frames.Add(BitmapFrame.Create(rtb));
              encoder.Save(outStream);
              System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(outStream);
              e.Graphics.DrawImage(bitmap, 0, 0);
          }
