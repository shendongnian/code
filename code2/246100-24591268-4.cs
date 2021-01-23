    /// <summary> An implementation of System.Random whose default constructor uses a random seed value rather than the system time. </summary>
    public class RandomEx : Random
    {
        /// <summary> Initializes a new CryptoRandom instance using a random seed value. </summary>
        public RandomEx()
            : base(_GetSeed())
        { }
        /// <summary> Initializes a new CryptoRandom instance using the specified seed value. </summary>
        /// <param name="seed"> The seed value. </param>
        public RandomEx(int seed)
            : base(seed)
        { }
        // The static (shared by all callers!) RandomNumberGenerator instance
        private static RandomNumberGenerator _rng = null;
        /// <summary> Static method that returns a random integer. </summary>
        private static int _GetSeed()
        {
            var seed = new byte[sizeof(int)];
            lock (typeof(RandomEx)) {
                // Initialize the RandomNumberGenerator instance if necessary
                if (_rng == null) _rng = new RNGCryptoServiceProvider();
                // Get the random bytes
                _rng.GetBytes(seed);
            }
            // Convert the bytes to an int
            return BitConverter.ToInt32(seed, 0);
        }
    }
