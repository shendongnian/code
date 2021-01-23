        public string path;
        public string fileName;
        public void GetExeLocation()
        {
            path = System.Reflection.Assembly.GetEntryAssembly().Location; // for getting the location of exe file ( it can change when you change the location of exe)
            fileName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name; // for getting the name of exe file( it can change when you change the name of exe)
            StartExeWhenPcStartup(fileName,path); // start the exe autometically when computer is stared.
        }
        public void StartExeWhenPcStartup(string filename,string filepath)
        {
            Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue(filename, filepath);
        }
