        public byte[] GetPixelDataAfterConvertingToJpeg(Image img)
        {
            using (var stream = new MemoryStream())
            {
                img.Save(stream, ImageFormat.Jpeg);
                stream.Position = 0;
                using (var jpg = Image.FromStream(stream))
                {
                    using (var bm = new Bitmap(jpg))
                    {
                        var data = bm.LockBits(new Rectangle(0, 0, bm.Width, bm.Height),
                            ImageLockMode.ReadOnly, bm.PixelFormat);
                        var bytes = new byte[data.Height * data.Stride];
                        Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
                        bm.UnlockBits(data);
                        return bytes;
                    }
                }
            }
        }
