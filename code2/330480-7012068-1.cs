    class Class
    {
        [DllImport("shlwapi.dll")]
        private static extern bool PathIsNetworkPath(string Path);
    
        [STAThread]
        static void Main(string[] args)
        {
            string strPath = "D:\\Temp\\tmpfile.txt";
            bool blnIsLocalPath = IsLocalPath(strPath);
            Console.WriteLine(blnIsLocalPath.ToString());
            Console.ReadLine();
        }
    
        private static bool IsLocalPath(string Path)
        {
            return !PathIsNetworkPath(Path);
        }
     }
