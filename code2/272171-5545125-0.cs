        public void DrawText(bool debug, Graphics g, string text, Font font, Brush brush, StringFormat format, float x, float y, float rotation)
        {
            if (debug)
            {
                g.FillEllipse(Brushes.Green, x - 5f, y - 5f, 10f, 10f);
            }
            GraphicsState gs = g.Save();
            SizeF textSize = g.MeasureString(text, font, SizeF.Empty, format);
            Matrix mat = new Matrix();
            mat.Shear(0f, 0f, MatrixOrder.Append);
            mat.Rotate(rotation, MatrixOrder.Append);
            mat.Translate(x, y, MatrixOrder.Append);
            g.Transform = mat;
            g.DrawString(text, font, brush, new PointF(0, 0), format);
            g.Restore(gs);
        }
