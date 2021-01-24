    using (MagickImage image = new MagickImage(imagePath)
            {
                image.Format = MagickFormat.Gray;
                byte[] imgarr = image.ToByteArray();
            }
