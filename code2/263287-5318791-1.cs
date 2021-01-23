    static void Main(string[] args)
    {
        foreach (Process process in Process.GetProcessesByName("firefox"))
        {
            string url = GetFirefoxUrl(process);
            if (url == null)
                continue;
            Console.WriteLine("FF Url for '" + process.MainWindowTitle + "' is " + url);
        }
        foreach (Process process in Process.GetProcessesByName("iexplore"))
        {
            string url = GetInternetExplorerUrl(process);
            if (url == null)
                continue;
            Console.WriteLine("IE Url for '" + process.MainWindowTitle + "' is " + url);
        }
        foreach (Process process in Process.GetProcessesByName("chrome"))
        {
            string url = GetChromeUrl(process);
            if (url == null)
                continue;
            Console.WriteLine("CH Url for '" + process.MainWindowTitle + "' is " + url);
        }
    }
