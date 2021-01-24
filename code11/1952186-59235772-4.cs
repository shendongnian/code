         using (MagickImage image = new MagickImage(@"YourImage.jpg"))
           {
               image.Format = image.Format; // Get or Set the format of the image.
               image.Resize(40, 40); // fit the image into the requested width and height. 
               image.Quality = 10; // This is the Compression level.
               image.Write("YourFinalImage.jpg");                 
            }
