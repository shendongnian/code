    public static class RandomExtension
    {
        public static int NextInclusive(this Random random, int minValue, int maxValue)
        {
            var randInt = random.Next(minValue, maxValue);
            var plus = random.Next(0, 2);
            return randInt + plus;
        }
    }
