    public class Program 
    {
        public struct SystemTime
        {
            public ushort Year;
            public ushort Month;
            public ushort DayOfWeek;
            public ushort Day;
            public ushort Hour;
            public ushort Minute;
            public ushort Second;
            public ushort Millisecond;
        };
        [DllImport("kernel32.dll", EntryPoint = "GetSystemTime", SetLastError = true)]
        public extern static void Win32GetSystemTime(ref SystemTime st);
        [DllImport("kernel32.dll", EntryPoint = "SetSystemTime", SetLastError = true)]
        public extern static bool Win32SetSystemTime(ref SystemTime st);
        public static void Main(string[] args)
        {
            SystemTime st = new SystemTime
            {
                Year = 2010, Month = 10, Day = 18, Hour = 16, Minute = 12, DayOfWeek = 1
            };
        }
    }
