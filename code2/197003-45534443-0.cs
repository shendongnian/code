        public static List<Rect> Subtract(this Rect rect, Rect subtracted)
        {
            if (rect.IsEmpty())
            {
                return _emptyList;
            }
            Rect intersectedRect = rect;
            intersectedRect.Intersect(subtracted);
            if (intersectedRect.IsEmpty())
            {
                return new List<Rect> { rect };
            }
            List<Rect> results = new List<Rect>();
            var topRect = GetTopRect(rect, subtracted);
            if (!topRect.IsEmpty())
            {
                results.Add(topRect);
            }
            var leftRect = GetLeftRect(rect, subtracted);
            if (!leftRect.IsEmpty())
            {
                results.Add(leftRect);
            }
            var rightRect = GetRightRect(rect, subtracted);
            if (!rightRect.IsEmpty())
            {
                results.Add(rightRect);
            }
            var bottomRect = GetBottomRect(rect, subtracted);
            if (!bottomRect.IsEmpty())
            {
                results.Add(bottomRect);
            }
            return results;
        }
        public static bool IsEmpty(this Rect rect)
        {
            return Math.Abs(rect.Height) < tolerance || Math.Abs(rect.Width) < tolerance;
        }
        private static Rect GetTopRect(Rect rect, Rect subtracted)
        {
            return new Rect(rect.TopLeft, new Point(rect.Right, subtracted.Top));
        }
        private static Rect GetRightRect(Rect rect, Rect subtracted)
        {
            return new Rect(subtracted.TopRight, new Point(rect.Right, subtracted.Bottom));
        }
        private static Rect GetLeftRect(Rect rect, Rect subtracted)
        {
            return new Rect(new Point(rect.Left, subtracted.Top), subtracted.BottomLeft);
        }
        private static Rect GetBottomRect(Rect rect, Rect subtracted)
        {
            return new Rect(new Point(rect.Left, subtracted.Bottom), rect.BottomRight);
        }
