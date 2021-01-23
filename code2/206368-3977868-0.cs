            var myPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            var homeDir = System.IO.Path.GetDirectoryName(myPath);
            var appPath = System.IO.Path.Combine(homeDir, "app.exe");
            var tempPath = System.IO.Path.Combine(homeDir, "temp.txt");
            ProcessStartInfo P = new ProcessStartInfo(appPath);
            P.WorkingDirectory = homeDir;
            P.Arguments = string.Format("\"{0}\" \"{1}\"", tempPath, _patchpath);
            // etc...
