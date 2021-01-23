        public static void Main(string[] args)
        {
            FileStream fs = new FileStream("spork.txt", FileMode.Open);
            byte[] bits = new byte[3];
            fs.Read(bits, 0, 3);
            // UTF8 byte order mark is: 0xEF,0xBB,0xBF
            if (bits[0] == 0xEF && bits[1] == 0xBB && bits[2] == 0xBF)
            {
            }
            Console.ReadLine();
        }
    }
