        public byte[] SplitBytes(byte[] bytes)
        {
            var mask = 0b10000000; // 128
            var splitBytes = new byte[bytes.Length * 2];
            for (int i = 0; i < bytes.Length; i++)
            {
                if ((bytes[i] & mask) == mask)
                {
                    splitBytes[i * 2] = (byte)(bytes[i] & ~mask);
                    splitBytes[i * 2 + 1] = 1;
                }
                else
                {
                    splitBytes[i * 2] = bytes[i];
                }
            }
            return splitBytes;
        }
        public byte[] CombineBytes(byte[] bytes)
        {
            var mask = 0b10000000; // 128
            var combinedBytes = new byte[bytes.Length / 2];
            for (int i = 0; i < bytes.Length; i += 2)
            {
                if (bytes[i + 1] == 1)
                {
                    combinedBytes[i / 2] = (byte)(bytes[i] | mask);
                }
                else
                {
                    combinedBytes[i / 2] = bytes[i];
                }
            }
            return combinedBytes;
        }
