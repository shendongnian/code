    static void DirSearch(string dir, string rootDir = null)
    {
        if(!new DirectoryInfo(dir).Exists)
          throw new Exception($"the provided directory {dir} is not valid.")
    
        if (rootDir == null)
        {
            rootDir = dir;
        }
        try
        {
            foreach (string f in Directory.GetFiles(dir))
            {
                string filename = f.Substring(rootDir.Length);
                Console.WriteLine(filename);
            }
            foreach (string d in Directory.GetDirectories(dir))
            {
                Console.WriteLine(d);
                DirSearch(d, rootDir);
            }
    
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
