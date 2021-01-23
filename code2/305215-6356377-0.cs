        static void Main()
        {
            long x = 000101456890L, y = 348324000433L, z = 888000033380L;
            Console.WriteLine(Convert.ToString(x, 16));
            Console.WriteLine(Convert.ToString(y, 16));
            Console.WriteLine(Convert.ToString(y, 16));
            Console.WriteLine(Pack(x));
            Console.WriteLine(Pack(y));
            Console.WriteLine(Pack(z));
            Console.WriteLine(Convert.ToInt64("60c1bfa", 16).ToString().PadLeft(12, '0'));
            Console.WriteLine(Convert.ToInt64("5119ba72b1", 16).ToString().PadLeft(12, '0'));
            Console.WriteLine(Convert.ToInt64("cec0ed3264", 16).ToString().PadLeft(12, '0'));
            Console.WriteLine(Unpack("Bgwb+g==").ToString().PadLeft(12, '0'));
            Console.WriteLine(Unpack("URm6crE=").ToString().PadLeft(12, '0'));
            Console.WriteLine(Unpack("zsDtMmQ=").ToString().PadLeft(12, '0'));
           
        }
        static string Pack(long value)
        {
            ulong a = (ulong)value; // make shift easy
            List<byte> bytes = new List<byte>(8);
            while (a != 0)
            {
                bytes.Add((byte)a);
                a >>= 8;
            }
            bytes.Reverse();
            var chunk = bytes.ToArray();
            return Convert.ToBase64String(chunk);
        }
        static long Unpack(string value)
        {
            var chunk = Convert.FromBase64String(value);
            ulong a = 0;
            for (int i = 0; i < chunk.Length; i++)
            {
                a <<= 8;
                a |= chunk[i];
            }
            return (long)a;
        }
