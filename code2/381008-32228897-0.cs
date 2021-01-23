    public static void DeleteFirefoxCache()
        {
            string profilesPath = @"Mozilla\Firefox\Profiles";
            string localProfiles = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), profilesPath);
            string roamingProfiles = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), profilesPath);
            if (Directory.Exists(localProfiles))
            {
                var profiles = Directory.GetDirectories(localProfiles).OfType<string>().ToList();
                profiles.RemoveAll(prfl => prfl.ToLowerInvariant().EndsWith("geolocation")); // do not delete this profile.
                
                profiles.ForEach(delegate(string path) 
                {                    
                    var files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList<string>();
                    foreach (string file in files)
                    {
                        if (!Common.IsFileLocked(new FileInfo(file)))
                            File.Delete(file);
                    }            
                });
            }
            if (Directory.Exists(roamingProfiles))
            {
                var profiles = Directory.GetDirectories(roamingProfiles).OfType<string>().ToList();
                profiles.RemoveAll(prfl => prfl.ToLowerInvariant().EndsWith("geolocation")); // do not delete this profile.
                profiles.ForEach(delegate(string path)
                {
                    var dirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories).OfType<string>().ToList();
                    dirs.ForEach(delegate(string dir) 
                    {
                        var files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories).ToList<string>();
                        foreach (string file in files)
                        {
                            if (!Common.IsFileLocked(new FileInfo(file)))
                                File.Delete(file);
                        }   
                    });
                    var files0 = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).OfType<string>().ToList();
                    files0.ForEach(delegate(string file) 
                    {
                        if (!Common.IsFileLocked(new FileInfo(file)))
                            File.Delete(file);
                    });
                });
            }                    
        }
