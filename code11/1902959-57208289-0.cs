    static class RandomExtension
    {
        private static readonly byte[] bytes = new byte[sizeof(int)];
        public static int InclusiveNext(this Random random, int min, int max)
        {
            if (max <= min)
                throw new ArgumentException($"max {max} should be greater than min {min}");
            if (max < int.MaxValue)
                // can safely increase 'max'
                return random.Next(min, max + 1);
            // now 'max' is definitely 'int.MaxValue'
            if (min > int.MinValue)
                // can safely decrease 'min'
                // so get ['min' - 1, 'max' - 1]
                // and move it to ['min', 'max']
                return random.Next(min - 1, max) + 1;
            
            // now 'max' is definitely 'int.MaxValue'
            // and 'min' is definitely 'int.MinValue'
            // so the only option is
            random.NextBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }
    }
