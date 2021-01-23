        public double ConvertMeasure(string measure)
        {
            measure = measure.ToLower().Replace(" ", "");
            measure = measure.Substring(0, measure.Length - 1);
            char m = measure.Last();
            if (char.IsDigit(m))
                return double.Parse(measure, CultureInfo.InvariantCulture);
            double ret = double.Parse(measure.Substring(0, measure.Length - 1),
                                      CultureInfo.InvariantCulture);
            switch (m)
            {
                case 'm': return ret / 1E3;
                case 'u': return ret / 1E6;
                case 'n': return ret / 1E9;
                case 'p': return ret / 1E12;
            }
            return ret;
        }
