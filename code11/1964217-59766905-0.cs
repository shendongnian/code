        public static DirectoryInfo LocateScriptsFolder(string baseDir)
        {
            var parent = Directory.GetParent(baseDir);
            if (parent.GetDirectories("DataFolder").Any())
            {
                return parent.GetDirectories("DataFolder").First();
            }
            return LocateScriptsFolder(parent.FullName);
        }
        var baseDir = AppDomain.CurrentDomain.BaseDirectory;
        var scripts = LocateScriptsFolder(baseDir);
        scripts.GetFiles("*.json").First();
        var json = File.ReadAllText(script.FullName);
