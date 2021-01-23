    class Program
    {
        [DllImport("user32.dll")]
        static extern int MapVirtualKey(uint uCode, uint uMapType);
        [DllImport("user32.dll")]
        private static extern int ToAscii(uint uVirtKey, uint uScanCode, byte[] lpKeyState, [Out] StringBuilder lpChar, uint uFlags);
        static void Main(string[] args)
        {
            byte[] keyState = new byte[256];
            ushort[] input = { 16, 53, 16, 66, 52, 48, 16, 54, 16, 84, 16, 69, 16, 83, 16, 84 };
            StringBuilder output = new StringBuilder();
            foreach (ushort vk in input)
                AppendChar(output, vk, ref keyState);
            Console.WriteLine(output);
            Console.ReadKey(true);
        }
        private static void AppendChar(StringBuilder output, ushort vKey, ref byte[] keyState)
        {
            if (MapVirtualKey(vKey, 2) == 0)
            {
                keyState[vKey] = 0x80;
            }
            else
            {
                StringBuilder chr = new StringBuilder(2);
                int n = ToAscii(vKey, 0, keyState, chr, 0);
                if (n > 0)
                    output.Append(chr.ToString(0, n));
                keyState = new byte[256];
            }
        }
    }
