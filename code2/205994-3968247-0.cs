        public static int CompareColors(Color a, Color b)
        {
            return 100 * (int)(
                1.0 - ((double)(
                    Math.Abs(a.R - b.R) +
                    Math.Abs(a.G - b.G) +
                    Math.Abs(a.B - b.B)
                ) / (256.0 * 3))
            );
        }
