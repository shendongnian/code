            using (Bitmap result = new Bitmap(26 * 512, 13 * 512))
            {
                for (int x = 0; x < 26; x++)
                    for (int y = 0; y < 13; y++)
                        using (Graphics g = Graphics.FromImage(result))
                            g.DrawImage(images[x, y], x * 512, y * 512);
                result.Save(file, format);
            }
