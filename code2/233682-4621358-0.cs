            public static void AddToByteArray(byte[] destination, int offset, long value)
            { InsertBytes(destination, offset, BitConverter.GetBytes(value)); }
            public static void AddToByteArray(byte[] destination, int offset, int value)
            { InsertBytes(destination, offset, BitConverter.GetBytes(value)); }
            public static void AddToByteArray(byte[] destination, int offset, short value)
            { InsertBytes(destination, offset, BitConverter.GetBytes(value)); }
            private static void InsertBytes(byte[] destination, int offset, byte[] bytes)
            {
                Buffer.BlockCopy(bytes, 0, destination, offset, bytes.Length);
            }
