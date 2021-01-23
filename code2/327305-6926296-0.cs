            public static bool Invert(Bitmap b)
            {
                BitmapData bmData = b.LockBits(new Rectangle(0, 0, b.Width, b.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                int stride = bmData.Stride;
                int bytes = Math.Abs(bmData.Stride) * b.Height;
                System.IntPtr Scan0 = bmData.Scan0;
                byte[] p = new byte[bytes];
                System.Runtime.InteropServices.Marshal.Copy(Scan0, p, 0, bytes);
                    int nOffset = stride - b.Width * 3;
                    int nWidth = b.Width * 3;
                    int i = 0;
                    for (int y = 0; y < b.Height; ++y)
                    {
                        for (int x = 0; x < nWidth; ++x)
                        {
                            p[i] = (byte)(255 - p[i]);
                            ++i;
                        }
                        i += nOffset;
                    }
                    System.Runtime.InteropServices.Marshal.Copy(p, 0, Scan0, bytes);
                b.UnlockBits(bmData);
                return true;
            }
