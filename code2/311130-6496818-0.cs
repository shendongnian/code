        private static Bitmap Resample(Image img, Size size) {
            var bmp = new Bitmap(size.Width, size.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (var gr = Graphics.FromImage(bmp)) {
                gr.DrawImage(img, new Rectangle(Point.Empty, size));
            }
            return bmp;
        }
