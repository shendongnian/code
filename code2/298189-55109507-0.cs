    public static class Loader
    {
        [DllImport("kernel32.dll")]
        public static extern IntPtr LoadLibrary(string fileName);
    }
