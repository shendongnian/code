    public static class RandomExtension
    {
        public static int NextInclusive(this Random random, int minValue, int maxValue)
        {
            var randInt = random.Next(int.MinValue, int.MaxValue);
            var plus = random.Next(0, 2);
            return randInt + plus;
        }
    }
