    public class ColorUtility
    {
        private Color color;
        public ColorUtility(Color original)
        {
            this.color = original;
        }
        public Color GetTransformedColor(Color overlay)
        {
            using(var bitmap = new Bitmap(1,1))
            {
                var g = Graphics.FromImage(bitmap);
                using(Brush baseBrush = new SolidBrush(this.color))
                {
                    g.FillRectangle(baseBrush,0,0,1,1);
                }
                using(Brush overlayBrush = new SolidBrush(Color.FromArgb(127,overlay)))
                {
                    g.FillRectangle(overlayBrush,0,0,1,1);
                }
                return bitmap.GetPixel(0, 0);
            }
        }
    }
