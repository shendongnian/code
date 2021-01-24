    var aspect_ratio = (decimal)image.Width / (decimal)image.Height;
        if (aspect_ratio > 1)
        {
             var newWidth = (int) Math.Round((decimal) (aspect_ratio * 150));
             image.Resize(newWidth, 150);
             // cut width and new width is multiply 150 by aspect ratio
        }
       else if (aspect_ratio < 1) 
       {
             //cut height and new height is multiply 150 by aspect ratio
             var newHeight = (int)Math.Round((decimal)((decimal)image.Height / (decimal)image.Width * 150));
             image.Resize(150, newHeight);
       }
       private void ProcessImage(MagickImage image, MemoryStream ms)
        {
            using var finalImage = new MagickImage(new MagickColor("#000000"), 150, 150);
            finalImage.Composite(image, Gravity.Center, CompositeOperator.Over);
            
            finalImage.Write(ms, MagickFormat.Jpg);
            image.Strip();
            image.Quality = 75;
        }
