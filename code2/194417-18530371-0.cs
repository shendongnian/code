        static void Main(string[] args)
        {
            Int32 a = 138;
            Console.WriteLine("first int: " + a.ToString());
            byte[] bytes = BitConverter.GetBytes(a);
            var bits = new BitArray(bytes);
            String lol = ToBitString(bits);
            Console.WriteLine("bit int: " + lol);
            lol = lol.Substring(1, lol.Length - 1) + lol[0];
            Console.WriteLine("left   : " + lol);
            byte[] bytes_new = GetBytes(lol);
            byte[] key = { 12, 13, 24, 85 };
            var bits2 = new BitArray(key);
            String lol2 = ToBitString(bits2);
            Console.WriteLine("key    : " + lol2);
            
            byte[] cryptedBytes = Crypt(bytes_new, key);
            var bits3 = new BitArray(cryptedBytes);
            String lol3 = ToBitString(bits3);
            Console.WriteLine("    XOR: " + lol3);
            byte[] deCryptedBytes = Crypt(cryptedBytes, key);
            var bits4 = new BitArray(cryptedBytes);
            String lol4 = ToBitString(bits4);
            Console.WriteLine("  DEXOR: " + lol4);
            int a_new = BitConverter.ToInt32(bytes_new, 0);
            Console.WriteLine("and int: " + a_new.ToString());
            Console.ReadLine();
        }
        public static byte[] Crypt(byte[] data, byte[] key)
        {
            byte[] toCrypt = data;
            for (int i = 0; i < toCrypt.Length; i++)
            {
                toCrypt[i] = (byte)(toCrypt[i] ^ key[i]);
            }
            return toCrypt;
        }
        private static String ToBitString(BitArray bits)
        {
            var sb = new StringBuilder();
            for (int i = bits.Count - 1; i >= 0; i--)
            {
                char c = bits[i] ? '1' : '0';
                sb.Append(c);
            }
            return sb.ToString();
        }
        private static byte[] GetBytes(string bitString)
        {
            byte[] result = Enumerable.Range(0, bitString.Length / 8).
                Select(pos => Convert.ToByte(
                    bitString.Substring(pos * 8, 8),
                    2)
                ).ToArray();
            List<byte> mahByteArray = new List<byte>();
            for (int i = result.Length - 1; i >= 0; i--)
            {
                mahByteArray.Add(result[i]);
            }
            return mahByteArray.ToArray();
        }
