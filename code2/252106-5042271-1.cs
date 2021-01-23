    public static class SPStringUtils
    {
        public static string MakeFilename(this DateTime dt)
        {
            return dt.ToString("yyyyMMdd-HHmmss");
        }
        public static string MakeFilename(this DateTime dt, string format)
        {
            return string.Format(format, MakeFilename(Now));
        }
    }
    ...
    Console.WriteLine(Now.MakeFilename(@"c:\logs\log{0}.log");
