        private static object mOverlayLock = new object();
        public static Image GetOverlayedImage(Image baseImage, Image overlay)
        {
            Image im = null;
            lock (mOverlayLock)
            {
                try
                {
                    im = baseImage.Clone() as Image;
                    Graphics g = Graphics.FromImage(im);
                    g.DrawImage(overlay, 0, 0, im.Width, im.Height);
                    g.Dispose();
                }
                catch
                {
                    // LOG EXCEPTION!!
                }
            }
            return im;
        }
