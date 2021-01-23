          var image = System.Drawing.Image.FromFile("..."); // or wherever it comes from
          var bitmap = new System.Drawing.Bitmap(image);
          var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(),
                                                                                IntPtr.Zero,
                                                                                Int32Rect.Empty,
                                                                                BitmapSizeOptions.FromEmptyOptions()
                );
          bitmap.Dispose();
          var brush = new ImageBrush(bitmapSource);          
