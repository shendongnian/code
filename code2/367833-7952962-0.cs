            using (Metafile img = new Metafile(@"c:\temp\test.wmf")) {
                MetafileHeader header = img.GetMetafileHeader();
                float scale = header.DpiX / 96f;
                using (Bitmap bitmap = new Bitmap((int)(scale * img.Width / header.DpiX * 100), (int)(scale * img.Height / header.DpiY * 100))) {
                    using (Graphics g = Graphics.FromImage(bitmap)) {
                        g.Clear(Color.White);
                        g.ScaleTransform(scale, scale);
                        g.DrawImage(img, 0, 0);
                    }
                    bitmap.Save(@"c:\temp\test.png", ImageFormat.Png);
                }
            }
