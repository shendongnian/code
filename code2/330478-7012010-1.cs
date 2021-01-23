    class Program
    {
        [DllImport("shlwapi.dll")]
        private static extern bool PathIsNetworkPath(string pszPath);
    
        static void Main(string[] args)
        {
            Console.WriteLine(PathIsNetworkPath("i:\Backup"));
        }
    }
