    void HideConsole()
    {
        MyConsole.FreeConsole();
    }
    internal class MyConsole
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        public static extern bool FreeConsole();
    }
