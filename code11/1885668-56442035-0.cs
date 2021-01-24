            static void Main(string[] args)
            {
                CopyFolder(@"D:\Origin", @"D:\Test");
                Console.ReadLine();
            }
    
            private static void CopyFolder(string source, string destination)
            {
                if (!Directory.Exists(destination))
                    Directory.CreateDirectory(destination);
    
                var files = new DirectoryInfo(source).GetFiles("*.pdf");
                string dailyFolder = "DailyFolder";
                string destinationDailyFolder = Path.Combine(destination, dailyFolder);
                foreach (var item in files)
                {                
                    if (!Directory.Exists(destinationDailyFolder))
                        Directory.CreateDirectory(destinationDailyFolder);
                    item.CopyTo(Path.Combine(destinationDailyFolder, item.Name),true);
                }
                var Directories = new DirectoryInfo(source).GetDirectories();
                foreach (var directory in Directories)
                {
                    CopyFolder(directory.FullName, Path.Combine(destination,directory.Name));
                }
            }
