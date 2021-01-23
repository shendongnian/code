        public static void DrawRoundedBorder(this Graphics g, Color color, Rectangle rec,
                                             int radius, int borderWidth, RoundedCorners corners)
        {
            using (Bitmap b = new Bitmap(rec.Width, rec.Height))
            using (Graphics gb = Graphics.FromImage(b))
            {
                var gfRec = new Rectangle(0, 0, rec.Width, rec.Height);
                gb.Clear(Color.Green);
                gb.DrawRoundedRectangle(color, gfRec, radius, corners);
                gfRec.Height -= borderWidth << 1;
                gfRec.Width -= borderWidth << 1;
                gfRec.X += borderWidth;
                gfRec.Y += borderWidth;
                gb.DrawRoundedRectangle(Color.Green, gfRec, radius - borderWidth, corners);
                var maskAttr = new ImageAttributes();
                maskAttr.SetColorKey(Color.Green, Color.Green);
                g.DrawImage(b, rec, 0, 0, b.Width, b.Height, GraphicsUnit.Pixel, maskAttr);
            }
        }
