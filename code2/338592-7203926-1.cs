        public static bool RunInstallMSI(string sMSIPath)
        {
            try
            {
                Console.WriteLine("Starting to install application");
                Process process = new Process();
                process.StartInfo.FileName = "msiexec.exe";
                process.StartInfo.Arguments = string.Format(" /qb /i \"{0}\" ALLUSERS=1", sMSIPath);      
                process.Start();
                process.WaitForExit();
                Console.WriteLine("Application installed successfully!");
                return true; //Return True if process ended successfully
            }
            catch
            {
                Console.WriteLine("There was a problem installing the application!");
                return false;  //Return False if process ended unsuccessfully
            }
        }
        public static bool RunUninstallMSI(string guid)
        {
            try
            {
                Console.WriteLine("Starting to uninstall application");
                ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", string.Format("/c start /MIN /wait msiexec.exe /x {0} /quiet", guid));
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                Process process = Process.Start(startInfo);
                process.WaitForExit();
                Console.WriteLine("Application uninstalled successfully!");
                return true; //Return True if process ended successfully
            }
            catch
            {
                Console.WriteLine("There was a problem uninstalling the application!");
                return false; //Return False if process ended unsuccessfully
            }
        }
