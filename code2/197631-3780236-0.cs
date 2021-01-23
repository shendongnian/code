        private bool IsImageTransparent(Bitmap image)
        {
            for (int i = 0; i < image.Width; i++)
                for (int j = 0; j < image.Height; j++)
            {
                var pixel = image.GetPixel(i, j);
                if (pixel.A != 255)
                    return true;
            } 
            return false;
        }
