    Assembly LoadWithoutCache(string path)
    {
        using (var fs = new FileStream(path, FileMode.Open))
        {
            var rawAssembly = new byte[fs.Length];
            fs.Read(rawAssembly, 0, rawAssembly.Length);
            return Assembly.Load(rawAssembly);
        }
    }
