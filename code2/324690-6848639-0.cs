        public static Bitmap SafeBitmap(Bitmap bmp)
        {
            //make output bmp.
            Bitmap b = new Bitmap(bmp.Width, bmp.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.Clear(Color.White);
                g.DrawImage(bmp, 0, 0);
            }
            return b;
        }
