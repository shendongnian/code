         bmp.Save("E:\\temp.png", System.Drawing.Imaging.ImageFormat.Png);
         //Again, a messy practice but required to allow access to the file.
         bmp = null;`
         GC.Collect();
         GC.WaitForPendingFinalizers();
         GC.Collect();
         
         //Load up the image.
         BitmapFrame frm = new BitmapFrame(new Uri("E:\\temp.png"));
         image.Source = frm as BitmapSource;
