        private byte TestULong(ulong value)
        {
            byte result = 0;
            for (int i = 0; i < 8; i++)
            {
                var test = (byte)(value >> (i * 8));
                if (test != 0)
                {
                    result = (byte)(result | (1 << i));
                }
            }
            return result;
        }
