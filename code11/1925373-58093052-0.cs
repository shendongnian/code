        Bitmap rotate(Bitmap img, float angle, int cx, int cy)
        {
            Bitmap result = new Bitmap(img.Width, img.Height);
            int mx = img.Width / 2,
                my = img.Height / 2;
            using (Graphics g = Graphics.FromImage(result))
            {
                g.Clear(Color.Black);
                g.TranslateTransform(cx, cy);
                g.RotateTransform(angle);
                g.TranslateTransform(-cx, -cy);
                g.TranslateTransform(mx - cx, my - cy, MatrixOrder.Append);
                g.DrawImage(originalImage, new Point(0, 0));
            }
            return result;
        }
