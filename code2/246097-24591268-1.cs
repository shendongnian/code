    public class CryptoRandom : Random
    {
        /// <summary> Returns a random number between 0.0 (inclusive) and 1.0 (exclusive). </summary>
        protected override double Sample()
        {
            byte[] bytes = new byte[sizeof(long)];
            using (var rng = new RNGCryptoServiceProvider()) {
                // Get a nonnegative random Int64
                rng.GetBytes(bytes);
                long l = BitConverter.ToInt64(bytes, 0) & Int64.MaxValue;
                // Scale it to 0->1
                return (double)l / (((double)Int64.MaxValue) + 1);
            }
        }
    }
