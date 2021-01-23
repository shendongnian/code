        public static Pen GetPrintablePen(Pen pen)
        {
            if (pen.Color.R == 255 && pen.Color.G == 255 && pen.Color.B == 255)
            {
                Pen newPen = (Pen)pen.Clone();
                newPen.Color = Color.Black;
                return newPen;
            }
            return pen;
        }
        public static SolidBrush GetPrintableBrush(SolidBrush brush)
        {
            if (brush.Color.R == 255 && brush.Color.G == 255 && brush.Color.B == 255)
            {
                SolidBrush newBrush = (SolidBrush)brush.Clone();
                newBrush.Color = Color.Black;
                return newBrush;
            }
            return brush;
        }
