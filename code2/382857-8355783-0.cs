    string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    string fullpath = Path.Combine(path, @"FT933\FT33_1");
    using (StreamReader reader = new StreamReader(fullpath))
    {
        string ret = reader.ReadLine();
    }            
