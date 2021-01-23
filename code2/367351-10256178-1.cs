    using System.Runtime.InteropServices;
    namespace
    {
        class Program
        {
            [DllImport("kernel32.dll")]
            public static extern bool SetConsoleTextAttribute(IntPtr hConsoleOutput, int wAttributes);
            [DllImport("kernel32.dll")]
            public static extern IntPtr GetStdHandle(uint nStdHandle);
            static void Main(string[] args)
            {
                uint STD_OUTPUT_HANDLE = 0xfffffff5;
                IntPtr hConsole = GetStdHandle(STD_OUTPUT_HANDLE);
                SetConsoleTextAttribute(hConsole, (int)Colour.Red + (int)Colour.Green + (int)Colour.Intensity);
                Console.WriteLine("Red + Green + Intensity == Yellow");
                SetConsoleTextAttribute(hConsole, (int)Colour.Red + (int)Colour.Green + (int)Colour.Intensity + (int)Colour.Red);
                Console.WriteLine("Yellow + Red != Orange");
            
                SetConsoleTextAttribute(hConsole, 15);
                Console.WriteLine();
                Console.WriteLine("Press Enter to exit ...");
                Console.Read();
            }
            public enum Colour
            {
                Blue = 0x00000001,
                Green = 0x00000002,
                Red = 0x00000004,
                Intensity = 0x00000008
            }
        }
    }
