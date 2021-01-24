    public static int MaxIndexByCustomRule(this IEnumerable<double> sequence)
        {
            int index = 0;
            int maxIndex = -1;
            double maxResult = double.MinValue;
            foreach (var value in sequence)
            {
                var tempResult = value - value * value;
                if (tempResult > maxResult)
                {
                    maxResult = tempResult;
                    maxIndex = index;
                }
                index++;
            }
            return maxIndex;
        }
