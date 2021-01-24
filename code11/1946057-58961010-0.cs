    foreach (FileInfo file in directory.EnumerateFiles("*.webloc",SearchOption.AllDirectories))
    {
        try
        {
            if (!file.Attributes.HasFlag(FileAttributes.Hidden) && file.Length != 0)
            {
                XElement url = XElement.Load(File.OpenRead(file.FullName));
            IEnumerable<string> partNos = from item in url.Descendants("string")
                                          select (string)item.Value;
            string result = Path.GetFileNameWithoutExtension(file.FullName);
            // Write filenames to string
            foreach (var part in partNos)
            {
                Console.WriteLine("\t<DT><A HREF={0}>{1}</A>",part, result); 
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
    }
