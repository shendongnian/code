    public static class DirectoryEx
    {
        static char driveLetter;
        static string longPath;
        static List<string> directories;
        static DirectoryEx()
        {
            longPath = String.Empty;
        }
        private static char GetAvailableDrive()
        {
            var all = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().Reverse();
            var occupied = DriveInfo.GetDrives()
                .OrderByDescending(d => d.Name)
                .Select(d => (char)d.Name.ToUpper().First());
            var free = all.Except(occupied).First();
            return free;
        }
        public static List<string> GetDirectories(string path)
        {
            directories = new List<string>();
            // recursive call
            FindDirectories(path);
            return directories;
        }
        static void FindDirectories(string path)
        {
            try
            {
                foreach (var directory in Directory.GetDirectories(path))
                {
                    var di = new DirectoryInfo(directory);
                    if(!String.IsNullOrEmpty(longPath))
                        directories.Add(di.FullName.Replace(driveLetter + ":\\", longPath + "\\"));
                    else
                        directories.Add(di.FullName);
                    FindDirectories(di.FullName);
                }
            }
            catch (UnauthorizedAccessException uaex) { Debug.WriteLine(uaex.Message); }
            catch (PathTooLongException ptlex)
            {
                Debug.WriteLine(ptlex.Message);
                longPath = path;
                Task t = new Task(new Action(() =>
                {
                    CreateVirtualDrive(longPath);
                    FindDirectories(driveLetter + ":\\");
                    DeleteVirtualDrive();
                    longPath = String.Empty;
                }));
                if (!String.IsNullOrEmpty(longPath))
                    t.RunSynchronously();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message); 
            }
        }
        static void CreateVirtualDrive(string path)
        {
            driveLetter = GetAvailableDrive();
            Process.Start(new ProcessStartInfo() {
                FileName = "cmd.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = String.Format("/c subst {0}: {1}", driveLetter.ToString(), path)
            });
            while (!DriveInfo.GetDrives().Select(d => d.Name.ToUpper().First()).Contains(driveLetter))
            {
                System.Threading.Thread.Sleep(1);
            }
        }
        static void DeleteVirtualDrive()
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                Arguments = String.Format("/c subst {0}: /D", driveLetter.ToString())
            });
            while (DriveInfo.GetDrives().Select(d => d.Name.ToUpper().First()).Contains(driveLetter))
            {
                System.Threading.Thread.Sleep(1);
            }
        }
    }
