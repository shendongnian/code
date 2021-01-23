    /// <summary> An implementation of System.Random that uses RNGCryptoServiceProvider to provide random values. </summary>
    public class CryptoRandom : Random, IDisposable
    {
        // Class data
        RandomNumberGenerator _csp = new RNGCryptoServiceProvider();
        /// <summary> Returns a random number between 0.0 (inclusive) and 1.0 (exclusive). </summary>
        protected override double Sample()
        {
            // Get a nonnegative random Int64
            byte[] bytes = new byte[sizeof(long)];
            _csp.GetBytes(bytes);
            long value = BitConverter.ToInt64(bytes, 0) & long.MaxValue;
            // Scale it to 0->1
            return (double)value / (((double)Int64.MaxValue) + 1025.0d);
        }
        /// <summary> Fills the elements of the specified array of bytes with random numbers. </summary>
        /// <param name="buffer"> An array of bytes to contain random numbers. </param>
        public override void NextBytes(byte[] buffer)
        {
            _csp.GetBytes(buffer);
        }
        /// <summary> Returns a nonnegative random integer. </summary>
        /// <returns> A 32-bit signed integer greater than or equal to zero. </returns>
        public override int Next()
        {
            byte[] data = new byte[4];
            _csp.GetBytes(data);
            data[3] &= 0x7f;
            return BitConverter.ToInt32(data, 0);
        }
        /// <summary> Returns a random integer that is within a specified range. </summary>
        /// <param name="minValue"> The inclusive lower bound of the random number returned. </param>
        /// <param name="maxValue"> The exclusive upper bound of the random number returned. maxValue must be greater than or equal to minValue. </param>
        /// <returns> A 32-bit signed integer greater than or equal to minValue and less than maxValue; that is, the range of return values includes minValue but not maxValue. If minValue equals maxValue, minValue is returned. </returns>
        public override int Next(int minValue, int maxValue)
        {
            // Special case
            if (minValue == maxValue) return minValue;
            double sample = Sample();
            double range = (double)maxValue - (double)minValue;
            return (int)((sample * (double)range) + (double)minValue);
        }
        #region IDisposible implementation
        /// <summary> Disposes the CryptoRandom instance and all of its allocated resources. </summary>
        public void Dispose()
        {
            // Do the actual work
            Dispose(true);
            // This object will be cleaned up by the Dispose method. Call GC.SupressFinalize to 
            // take this object off the finalization queue and prevent finalization code for this object 
            // from executing a second time.
            GC.SuppressFinalize(this);
        }
        // Dispose(bool disposing) executes in two distinct scenarios:
        //
        // If disposing is true, the method has been called directly or indirectly by a user's code and both
        // managed and unmanaged resources can be disposed. 
        //
        // If disposing is false, the method has been called by the runtime from inside the finalizer.
        // In this case, only unmanaged resources can be disposed. 
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) {
                // The method has been called directly or indirectly by a user's code; dispose managed resources (if any)
                if (_csp != null) {
                    _csp.Dispose();
                    _csp = null;
                }
                // Dispose unmanaged resources (if any)
            }
        }
        #endregion
    }
