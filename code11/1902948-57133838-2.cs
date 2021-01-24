    public static class RandomExtensions
    {
        public static int NextInclusive(this Random random, int minValue, int maxValue)
        {
            if (maxValue == Int32.MaxValue)
            {
                if (minValue == Int32.MinValue)
                {
                    var value1 = random.Next(Int32.MinValue, Int32.MaxValue);
                    var value2 = random.Next(Int32.MinValue, Int32.MaxValue);
                    return value1 < value2 ? value1 : value1 + 1;
                }
                return random.Next(minValue - 1, Int32.MaxValue) + 1;
            }
            return random.Next(minValue, maxValue + 1);
        }
    }
