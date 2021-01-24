            public void Convert()
            {
                string filePath = "C:\\Users\\User\\Desktop\\sample.mid";
                byte[] bytes = File.ReadAllBytes(filePath);
                int pixelCount = (int)Math.Ceiling(bytes.Count() / 4.0);
                double width = Math.Ceiling(Math.Sqrt(pixelCount));
                double height = Math.Ceiling(pixelCount / width);
                string outputPath = "C:\\Users\\User\\Desktop\\sample.bmp";
                SaveAsBmp((int)width, (int)height, bytes, outputPath);
            }
    
            public void SaveAsBmp(int width, int height, byte[] argbData, string path)
            {
                using (Bitmap img = new Bitmap(width, height, PixelFormat.Format32bppPArgb))
                {
                    BitmapData data = img.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, img.PixelFormat);
                    for (int y = 0; y < height; y++)
                    {
                        Marshal.Copy(argbData, width * y, data.Scan0 + data.Stride * y, width * 4);
                    }
                    img.UnlockBits(data);
                    img.Save(path, ImageFormat.Bmp);
                }
            }
