        public static Bitmap ManagedSafeBitmap(string file)
        {
            using (var img = Image.FromFile(file))
            {
                var bmp = new Bitmap(img.Width, img.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    g.DrawImage(img, 0, 0);
                }
                return bmp;
            }
        }
