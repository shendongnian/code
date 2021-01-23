    public static class SecureRandom
    {
        #region Constants
        private const int INT_SIZE = 4;
        private const int INT64_SIZE = 8;
        #endregion
        #region Fields
        private static RandomNumberGenerator _Random;
        #endregion
        #region Constructor
        static SecureRandom()
        {
            _Random = new RNGCryptoServiceProvider();
        }
        #endregion
        #region Random Int32
        /// <summary>
        /// Get the next random integer
        /// </summary>
        /// <returns>Random [Int32]</returns>
        public static Int32 Next()
        {
            byte[] data = new byte[INT_SIZE];
            Int32[] result = new Int32[1];
            _Random.GetBytes(data);
            Buffer.BlockCopy(data, 0, result, 0, INT_SIZE);
            return result[0];
        }
        /// <summary>
        /// Get the next random integer to a maximum value
        /// </summary>
        /// <param name="MaxValue">Maximum value</param>
        /// <returns>Random [Int32]</returns>
        public static Int32 Next(Int32 MaxValue)
        {
            Int32 result = 0;
            do
            {
                result = Next();
            } while (result > MaxValue);
            return result;
        }
        #endregion
        #region Random UInt32
        /// <summary>
        /// Get the next random unsigned integer
        /// </summary>
        /// <returns>Random [UInt32]</returns>
        public static UInt32 NextUInt()
        {
            byte[] data = new byte[INT_SIZE];
            Int32[] result = new Int32[1];
            do
            {
                _Random.GetBytes(data);
                Buffer.BlockCopy(data, 0, result, 0, INT_SIZE);
            } while (result[0] < 0);
            return (UInt32)result[0];
        }
        /// <summary>
        /// Get the next random unsigned integer to a maximum value
        /// </summary>
        /// <param name="MaxValue">Maximum value</param>
        /// <returns>Random [UInt32]</returns>
        public static UInt32 NextUInt(UInt32 MaxValue)
        {
            UInt32 result = 0;
            do
            {
                result = NextUInt();
            } while (result > MaxValue);
            return result;
        }
        #endregion
        #region Random Int64
        /// <summary>
        /// Get the next random integer
        /// </summary>
        /// <returns>Random [Int32]</returns>
        public static Int64 NextLong()
        {
            byte[] data = new byte[INT64_SIZE];
            Int64[] result = new Int64[1];
            _Random.GetBytes(data);
            Buffer.BlockCopy(data, 0, result, 0, INT64_SIZE);
            return result[0];
        }
        /// <summary>
        /// Get the next random unsigned long to a maximum value
        /// </summary>
        /// <param name="MaxValue">Maximum value</param>
        /// <returns>Random [UInt64]</returns>
        public static Int64 NextLong(Int64 MaxValue)
        {
            Int64 result = 0;
            do
            {
                result = NextLong();
            } while (result > MaxValue);
            return result;
        }
        #endregion
        #region Random UInt32
        /// <summary>
        /// Get the next random unsigned long
        /// </summary>
        /// <returns>Random [UInt64]</returns>
        public static UInt64 NextULong()
        {
            byte[] data = new byte[INT64_SIZE];
            Int64[] result = new Int64[1];
            do
            {
                _Random.GetBytes(data);
                Buffer.BlockCopy(data, 0, result, 0, INT64_SIZE);
            } while (result[0] < 0);
            return (UInt64)result[0];
        }
        /// <summary>
        /// Get the next random unsigned long to a maximum value
        /// </summary>
        /// <param name="MaxValue">Maximum value</param>
        /// <returns>Random [UInt64]</returns>
        public static UInt64 NextULong(UInt64 MaxValue)
        {
            UInt64 result = 0;
            do
            {
                result = NextULong();
            } while (result > MaxValue);
            return result;
        }
        #endregion
        #region Random Bytes
        /// <summary>
        /// Get random bytes
        /// </summary>
        /// <param name="data">Random [byte array]</param>
        public static byte[] NextBytes(long Size)
        {
            byte[] data = new byte[Size];
            _Random.GetBytes(data);
            return data;
        }
        #endregion
    }
