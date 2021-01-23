    public class CryptoRandom : Random
    {
        // Class data
        RandomNumberGenerator _csp = new RNGCryptoServiceProvider();
        /// <summary> Returns a random number between 0.0 (inclusive) and 1.0 (exclusive). </summary>
        protected override double Sample()
        {
            // Get a nonnegative random Int64
            byte[] bytes = new byte[sizeof(long)];
            _csp.GetBytes(bytes);
            long value = BitConverter.ToInt64(bytes, 0) & Int64.MaxValue;
            // Scale it to 0->1
            return (double)value / (((double)Int64.MaxValue) + 1);
        }
    }
