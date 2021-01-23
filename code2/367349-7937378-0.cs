       public static class Win32
        {
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool SetConsoleTextAttribute(IntPtr hConsoleOutput, short attributes);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr GetStdHandle(int nStdHandle);
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                foreach(var i in Enumerable.Range(0, 100)) // why "100"? it is just any number
                {
                    Win32.SetConsoleTextAttribute(Win32.GetStdHandle(-11), (short)i);
                    Console.WriteLine("Hello");
                }
            }
        }
