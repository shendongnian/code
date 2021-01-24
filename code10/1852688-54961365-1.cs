        public static void DrawRectangles<T>(this Image thisImage, T rectangles, Color color) where T : IEnumerable
        {
            using (var g = Graphics.FromImage(thisImage))
            {
                var brush = new SolidBrush(color);
                if (rectangles.Cast<object>().FirstOrDefault().GetType() == typeof(Rectangle))
                {
                    g.FillRectangles(brush, rectangles.Cast<Rectangle>().ToArray());
                }
                else
                {
                    g.FillRectangles(brush, rectangles.Cast<RectangleF>().ToArray());
                }
            }
        }
        public static void Main(string[] args)
        {
            List<Rectangle> r = new List<Rectangle>();
            List<RectangleF> rf = new List<RectangleF>();
            r.Add(new Rectangle(10, 10, 10, 10));
            rf.Add(new RectangleF(10.4f, 10.4f, 10.4f, 10.4f));
            DrawRectangles(new Bitmap(10, 10), rf, Color.Aqua);
        }
