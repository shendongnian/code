        public void DrawText(bool debug, Graphics g, string text, Font font, Brush brush, StringFormat format, float x, float y, float width, float height, float rotation)
        {
            float centerX = width / 2;
            float centerY = height / 2;
            if (debug)
            {
                g.FillEllipse(Brushes.Green, centerX - 5f, centerY - 5f, 10f, 10f);
            }
            GraphicsState gs = g.Save();
            Matrix mat = new Matrix();
            mat.RotateAt(rotation, new PointF(centerX, centerY), MatrixOrder.Append);
            g.Transform = mat;
            SizeF szf = g.MeasureString(text, font);
            g.DrawString(text, font, brush, (width / 2) - (szf.Width / 2), (height / 2) - (szf.Height / 2), format);
            g.Restore(gs);
        }
