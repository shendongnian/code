        using (Bitmap newBmp = new Bitmap(size.Width, size.Height))
        {
            using (Graphics canvas = Graphics.FromImage(newBmp))
            {
                canvas.SmoothingMode = SmoothingMode.HighQuality;
                canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
                canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;
                canvas.DrawImage(newImage, new Rectangle(new Point(0, 0), size));
                using (var stream = new FileStream(newLocation, FileMode.Create))
                {
                    // keep image in existing format
                    var newFormat = newImage.RawFormat;
                    var encoder = GetEncoder(newFormat);
                    var parameters = new EncoderParameters(1);
                    parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
    
                    newBmp.Save(stream, encoder, parameters);
                    stream.Flush();
                }
            }
        }
