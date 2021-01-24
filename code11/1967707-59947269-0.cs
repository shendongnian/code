       private void ProcessImage(MagickImage image, MemoryStream ms)
        {
            using var finalImage = new MagickImage(new MagickColor("#000000"), 150, 150);
            finalImage.Composite(image, Gravity.Center, CompositeOperator.Over);
            
            finalImage.Write(ms, MagickFormat.Jpg);
            image.Strip();
            image.Quality = 75;
        }
