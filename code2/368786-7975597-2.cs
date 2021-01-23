            Bitmap bmp = new Bitmap(28, 28);
            int c = 0;
            for (int i = 0; i < 28; i++)
            {
                for (int j = 0; j < 28; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(i, i, i));
                }
            }
            bmp.Save("test.jpg", ImageFormat.Jpeg);
