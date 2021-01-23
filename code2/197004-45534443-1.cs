        public static List<Rect> Subtract(this Rect rect, Rect subtracted)
        {
            if (rect.HasNoArea())
            {
                return _emptyList;
            }
            if (rect.Equals(subtracted))
            {
                return new List<Rect>{new Rect(0, 0, 0, 0)};
            }
            Rect intersectedRect = rect;
            intersectedRect.Intersect(subtracted);
            if (intersectedRect.HasNoArea())
            {
                return new List<Rect> { rect };
            }
            List<Rect> results = new List<Rect>();
            var topRect = GetTopRect(rect, subtracted);
            if (!topRect.HasNoArea())
            {
                results.Add(topRect);
            }
            var leftRect = GetLeftRect(rect, subtracted);
            if (!leftRect.HasNoArea())
            {
                results.Add(leftRect);
            }
            var rightRect = GetRightRect(rect, subtracted);
            if (!rightRect.HasNoArea())
            {
                results.Add(rightRect);
            }
            var bottomRect = GetBottomRect(rect, subtracted);
            if (!bottomRect.HasNoArea())
            {
                results.Add(bottomRect);
            }
            return results;
        }
        public static bool HasNoArea(this Rect rect)
        {
            return rect.Height < tolerance || rect.Width < tolerance;
        }
        private static Rect GetTopRect(Rect rect, Rect subtracted)
        {
            return new Rect(rect.Left, rect.Top, rect.Width, Math.Max(subtracted.Top, 0));
        }
        private static Rect GetRightRect(Rect rect, Rect subtracted)
        {
            return new Rect(subtracted.Right, subtracted.Top, Math.Max(rect.Right - subtracted.Right, 0), subtracted.Height);
        }
        private static Rect GetLeftRect(Rect rect, Rect subtracted)
        {
            return new Rect(rect.Left, subtracted.Top, Math.Max(subtracted.Left - rect.Left, 0), subtracted.Height);
        }
        private static Rect GetBottomRect(Rect rect, Rect subtracted)
        {
            return new Rect(rect.Left, subtracted.Bottom, rect.Width, Math.Max(rect.Height - subtracted.Bottom, 0));
        }
