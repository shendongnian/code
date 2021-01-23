            // detect if 64-bit system
            string programFiles = "";
            if (Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").Contains("64"))
            {
                Console.WriteLine("#info# x64 detected");
                programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            }
            else
            {
                Console.WriteLine("#info# x86 detected");
                programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
            }
            
            // search
            string[] dirs = Directory.GetDirectories(programFiles, "CCleaner", SearchOption.AllDirectories);
            string[] exes = Directory.GetFiles(programFiles, "CCleaner64.exe", SearchOption.AllDirectories);
            
            //debug only
            foreach (string s in dirs)
            {
                Console.WriteLine(s);
            }
            foreach (string s in exes)
            {
                Console.WriteLine(s);
            }
            // access directly
            ProcessStartInfo CCleaner = new ProcessStartInfo(exes[0], "/AUTO");
            Process.Start(CCleaner);
