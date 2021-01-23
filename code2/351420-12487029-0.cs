    static class LibVlc
    {
        . . .
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetDllDirectory(string lpPathName);
        . . .
    }
