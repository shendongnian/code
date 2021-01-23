    using System;
    using System.Security.Cryptography;
    static class RNGUtil
    {
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="min" /> is greater than <paramref name="max" />.</exception>
        public static int Next(int min, int max)
        {
            if (min > max) throw new ArgumentOutOfRangeException(nameof(min));
            if (min == max) return min;
            using (var rng = new RNGCryptoServiceProvider())
            {
                var data = new byte[4];
                rng.GetBytes(data);
                int generatedValue = Math.Abs(BitConverter.ToInt32(data, startIndex: 0));
                int diff = max - min;
                int mod = generatedValue % diff;
                int normalizedNumber = min + mod;
                return normalizedNumber;
            }
        }
    }
