        public dynamic func(string s)
        {
            double d = 0;
            if (double.TryParse(s, out d))
                return Math.Round(d, 4);
            return s;
        }
