    using System;
    using System.Runtime.Intrinsics.X86;
    using System.Security.Cryptography;
    /// <summary>
    /// The hardware implementation of the CRC32-C polynomial 
    /// implemented on Intel CPUs supporting SSE4.2.
    /// </summary>
    public class Crc32HardwareAlgorithm : HashAlgorithm
    {
        /// <summary>
        /// the current CRC value, bit-flipped
        /// </summary>
        private uint _crc;
        /// <summary>
        /// We can further optimize the algorithm when X64 is available.
        /// </summary>
        private bool _x64Available;
        /// <summary>
        /// Default constructor
        /// </summary>
        public Crc32HardwareAlgorithm()
        {
            if (!Sse42.IsSupported)
            {
                throw new NotSupportedException("SSE4.2 is not supported");
            }
            _x64Available = Sse42.X64.IsSupported;
            // The size, in bits, of the computed hash code.
            this.HashSizeValue = 32;
            this.Reset();
        }
        /// <summary>When overridden in a derived class, routes data written to the object into the hash algorithm for computing the hash.</summary>
        /// <param name="array">The input to compute the hash code for.</param>
        /// <param name="ibStart">The offset into the byte array from which to begin using data.</param>
        /// <param name="cbSize">The number of bytes in the byte array to use as data.</param>
        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            if (_x64Available)
            {
                while (cbSize >= 8)
                {
                    _crc = (uint)Sse42.X64.Crc32(_crc, BitConverter.ToUInt64(array, ibStart));
                    ibStart += 8;
                    cbSize -= 8;
                }
            }
            while (cbSize > 0)
            {
                _crc = Sse42.Crc32(_crc, array[ibStart]);
                ibStart++;
                cbSize--;
            }
        }
        /// <summary>When overridden in a derived class, finalizes the hash computation after the last data is processed by the cryptographic stream object.</summary>
        /// <returns>The computed hash code.</returns>
        protected override byte[] HashFinal()
        {
            uint outputCrcValue = ~_crc;
            return BitConverter.GetBytes(outputCrcValue);
        }
        /// <summary>Initializes an implementation of the <see cref="T:System.Security.Cryptography.HashAlgorithm"></see> class.</summary>
        public override void Initialize()
        {
            this.Reset();
        }
        private void Reset()
        {
            _crc = uint.MaxValue;
        }
    }
