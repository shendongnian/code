            using (var m = new MemoryStream())
            {
                using (var img = Image.FromFile(args[0]))
                {
                    img.Save(m, ImageFormat.Bmp);
                }
                m.Position = 0;
                using (var bitmap = (Bitmap)Bitmap.FromStream(m))
                {
                    for (var x = 0; x < bitmap.Width; x++)
                    {
                        for (var y = 0; y < bitmap.Height; y++)
                        {
                            var color = bitmap.GetPixel(x, y);
                            // TODO: Do what ever you want
                        }
                    }
                }
            }
