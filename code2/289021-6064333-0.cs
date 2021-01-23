     public static ImageSource GetIconWithText(int digit)
     {
         BitmapImage myBitmapImage = new BitmapImage(new Uri(@"Images\PomoDomo.ico", 
             UriKind.RelativeOrAbsolute));
         
         DrawingVisual drawingVisual = new DrawingVisual();
    
         using (DrawingContext drawingContext = drawingVisual.RenderOpen())
         {
             // Draw image
             drawingContext.DrawImage(myBitmapImage, new Rect(0, 0, myBitmapImage.Width, 
                 myBitmapImage.Height));
    
             var typeFace = new Typeface(new FontFamily("Verdana"), FontStyles.Normal, 
                 FontWeights.ExtraBold, FontStretches.UltraCondensed);
             var formatedText = new FormattedText(digit.ToString(),
                   CultureInfo.InvariantCulture,
                   FlowDirection.LeftToRight,
                   typeFace,
                   40, 
                   System.Windows.Media.Brushes.White);
    
             //Center the text on Image
             int pointY = (int)(myBitmapImage.Height - formatedText.Height) / 2;
             int pointX = (int)(myBitmapImage.Width - formatedText.Width) / 2;
    
             drawingContext.DrawText(formatedText, new Point(pointX, pointY));
         }
    
         RenderTargetBitmap finalBitmap = new RenderTargetBitmap((int)myBitmapImage.Width, 
             (int)myBitmapImage.Height, myBitmapImage.DpiX, myBitmapImage.DpiY, 
             PixelFormats.Pbgra32);
         finalBitmap.Render(drawingVisual);
         return finalBitmap;
     }
    
     private static void SaveImage(RenderTargetBitmap returnBitmap, string pngFileName)
     {
         string fileName = string.Format("{0}.png", pngFileName)
         PngBitmapEncoder image = new PngBitmapEncoder();
         image.Frames.Add(BitmapFrame.Create(returnBitmap));
         using (Stream fs = File.Create(fileName))
         {
             image.Save(fs);
         }
     }
