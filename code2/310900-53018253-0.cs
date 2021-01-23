    public static class Crc32Checksum
    {
        private static readonly uint[] Table = GenerateTable();
        /// <summary>
        /// Calculates a new CRC32 value given additional data for current CRC value
        /// </summary>
        /// <param name="currentCrc">The current CRC value to start with</param>
        /// <param name="data">Additional data contents</param>
        /// <param name="offset">Byte offset to start reading</param>
        /// <param name="count">Number of bytes to read</param>
        /// <returns>The computer CRC32 value.</returns>
        public static int Calculate(int currentCrc, byte[] data, int offset, int count)
        {
            unchecked
            {
                uint crc = (uint)currentCrc ^ 0xFFFFFFFF;
                for (int i = offset, end = offset + count; i < end; i++)
                    crc = (crc >> 8) ^ Table[(crc ^ data[i]) & 0xFF];
                return (int)(crc ^ 0xFFFFFFFF);
            }
        }
        /// <summary>
        /// Calculates a CRC32 value for the data given
        /// </summary>
        /// <param name="data">Data contents</param>
        /// <param name="offset">Byte offset to start reading</param>
        /// <param name="count">Number of bytes to read</param>
        /// <returns>The computer CRC32 value.</returns>
        public static int Calculate(byte[] data, int offset, int count) => Calculate(0, data, offset, count);
        private static uint[] GenerateTable()
        {
            unchecked
            {
                var table = new uint[256];
                const uint poly = 0xEDB88320;
                for (uint i = 0; i < table.Length; i++)
                {
                    uint crc = i;
                    for (int j = 8; j > 0; j--)
                    {
                        if ((crc & 1) == 1)
                            crc = (crc >> 1) ^ poly;
                        else
                            crc >>= 1;
                    }
                    table[i] = crc;
                }
                return table;
            }
        }
    }
