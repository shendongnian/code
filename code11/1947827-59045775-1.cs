    static void Main(string[] args)
    {
        // determine the package root, based on own location
        string result = Assembly.GetExecutingAssembly().Location;
        int index = result.LastIndexOf("\\");
        string rootPath = $"{result.Substring(0, index)}\\..\\";
    
        // process object to keep track of your child process
        Process newProcess = null;
    
        if (args.Length > 2)
        {
            // launch process based on parameter
            switch (args[2])
            {
                case "/background":
                    newProcess = Process.Start(rootPath + @"FullTrust_Background\FullTrust_Background.exe");
                    break;
                     
                case "/win32":
                    newProcess = Process.Start(rootPath + @"FullTrust_Win32\FullTrust_Win32.exe");
                    break;             
              
            }
        }
    }
