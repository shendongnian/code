         using (MagickImage image = new MagickImage(@"YourImage.jpg"))
           {
               image.Format = image.Format;
               image.Resize(40, 40);
               image.Quality = 10;
               image.Write("YourFinalImage.jpeg");                  
            }
