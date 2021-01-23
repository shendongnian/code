     /// <summary>
        /// Get Intersection point
        /// </summary>
        /// <param name="a1">a1 is line1 start</param>
        /// <param name="a2">a2 is line1 end</param>
        /// <param name="b1">b1 is line2 start</param>
        /// <param name="b2">b2 is line2 end</param>
        /// <returns></returns>
        public static Vector? Intersects(Vector a1, Vector a2, Vector b1, Vector b2)
        {
            Vector b = a2 - a1;
            Vector d = b2 - b1;
            var bDotDPerp = b.X * d.Y - b.Y * d.X;
            // if b dot d == 0, it means the lines are parallel so have infinite intersection points
            if (bDotDPerp == 0)
                return null;
            Vector c = b1 - a1;
            var t = (c.X * d.Y - c.Y * d.X) / bDotDPerp;
            if (t < 0 || t > 1)
                {
                return null;
            }
            var u = (c.X * b.Y - c.Y * b.X) / bDotDPerp;
            if (u < 0 || u > 1)
            {
                return null;
            }
            return a1 + t * b;
        }
