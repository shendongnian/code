        static IList<double> FindPeaks(IList<double> values, int rangeOfPeaks)
        {
            List<double> peaks = new List<double>();
            int checksOnEachSide = rangeOfPeaks / 2;
            for (int i = 0; i < values.Count; i++)
            {
                double current = values[i];
                IEnumerable<double> range = values;
                if( i > checksOnEachSide )
                    range = range.Skip(i - checksOnEachSide);
                range = range.Take(rangeOfPeaks);
                if (current == range.Max())
                    peaks.Add(current);
            }
            return peaks;
        }
    
