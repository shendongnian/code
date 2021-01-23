        public double ConvertMeasure(string measure)
        {
            measure = measure.ToLower().Replace(" ", "").Replace(",", "");
            measure = measure.Substring(0, measure.Length - 1);
            string m = measure.Last().ToString();
            double ret = double.Parse(measure.Substring(0, measure.Length - 1));
            switch (m)
            {
                case "m": return ret / 1E3;
                case "u": return ret / 1E6;
                case "n": return ret / 1E9;
                case "p": return ret / 1E12;
            }
            return ret;
        }
