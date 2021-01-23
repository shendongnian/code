        public static string GetNumber(int length) {
            var rng = new Random(Environment.TickCount);
            var number = rng.NextDouble().ToString("0.000000000000").Substring(2, length);
            return number;
        }
