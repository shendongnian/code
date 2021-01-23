    class Program
    {
        // OP's method: http://stackoverflow.com/questions/4815959
        public static byte[] CryptPacket(byte[] packet)
        {
            int paksize = packet.Length - 2;
            for (int i = 2; i < paksize; i++)
            {
                packet[i] = (byte)(0x61 ^ packet[i]);
            }
            return packet;
        }
        
        // http://stackoverflow.com/questions/321370 :)
        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length).
                   Where(x => 0 == x % 2).
                   Select(x => Convert.ToByte(hex.Substring(x, 2), 16)).
                   ToArray();
        }
        
        static void Main(string[] args)
        {
            string hex = "0C 00 E2 66 65 47 4E 09 04 13 65 00".Replace(" ", "");
            byte[] input = StringToByteArray(hex);
            Console.WriteLine("Input: " + ASCIIEncoding.ASCII.GetString(input));
            byte[] output = CryptPacket(input);
            Console.WriteLine("Output: " + ASCIIEncoding.ASCII.GetString(output));
            Console.ReadLine();
        }
    }
