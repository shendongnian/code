    private static void ConvertFiles(string pathToSearchRecursive, string searchPattern)
    {
        var dir = new DirectoryInfo(pathToSearchRecursive);
        if (!dir.Exists)
        {
            throw new ArgumentException("Directory doesn't exists: " + dir.ToString());
        }
        if (String.IsNullOrEmpty(searchPattern))
        {
            throw new ArgumentNullException("searchPattern");
        }
        foreach (var file in dir.GetFiles(searchPattern, SearchOption.AllDirectories))
        {
            var tempFile = Path.GetTempFileName();
            // Use the using statement to make sure file is closed at the end or on error.
            using (var reader = file.OpenText())
            using (var writer = new StreamWriter(tempFile))
            {
                string line;
                while (null != (line = reader.ReadLine()))
                {
                    var split = line.Split((char)10);
                    foreach (var item in split)
                    {
                        writer.WriteLine(item);
                    }
                }
            }
            // Replace the original file be the converted one (if needed)
            ////File.Copy(tempFile, file.FullName, true);
        }
    }
