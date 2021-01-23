    Bitmap newBitmap = new Bitmap(original.Width, original.Height);
            for (int j = 0; j < original.Height; j++)
            {
                for (int i = 0; i < original.Width; i++)
                {
                    Color newColor = Color.FromArgb((int)grayScale[i + j * original.Width], (int)grayScale[i + j * original.Width], (int)grayScale[i + j * original.Width]);
                    newBitmap.SetPixel(i, j, newColor);
                }
            }
            Image img = newBitmap;
