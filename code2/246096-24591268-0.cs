    public class CryptoRandom : Random
    {
        /// <summary> Initializes a new CryptoRandom instance using a random seed value. </summary>
        public CryptoRandom()
            : base(_GetSeed())
        { }
        /// <summary> Initializes a new CryptoRandom instance using the specified seed value. </summary>
        /// <param name="seed"> The seed value. </param>
        public CryptoRandom(int seed)
            : base(seed)
        { }
        // The static (shared by all callers!) RandomNumberGenerator instance
        private static RandomNumberGenerator _rng = null;
        /// <summary> Static method that returns a random integer. </summary>
        /// <returns> A random integer. </returns>
        private static int _GetSeed() {
            lock (typeof(CryptoRandom)) {
                // Initialize the RandomNumberGenerator instance if necessary
                if (_rng == null) _rng = new RNGCryptoServiceProvider();
                // Ta dah...
                var seed = new byte[sizeof(int)];
                _rng.GetBytes(seed);
                return BitConverter.ToInt32(seed, 0);
            }
        }
    }
