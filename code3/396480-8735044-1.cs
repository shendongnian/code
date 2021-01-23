    private static List<IValueConverter> GetValueConverters( string rootDirectoryName)
    {
        List<IValueConverter> result = new List<IValueConverter>();
        string[] exts = new string[]{"*.exe", "*.dll"};
        DirectoryInfo di = new DirectoryInfo(rootDirectoryName);
        foreach(string ext in exts)
        {
            foreach(FileInfo fi in (di.GetFiles(ext, SearchOption.AllDirectories)))
            {
                Assembly a = Assembly.LoadFrom(fi.FullName);
                try
                {
                    List<Type> ts = a.GetExportedTypes().ToList();
                    foreach (Type t in ts)
                    {
                        var d2 = t.GetInterfaces().Where(q => q.Name == "IValueConverter");
                        if (d2.Count() > 0)
                        {
                            result.Add(Activator.CreateInstance(t) as IValueConverter);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        return result;
    }
