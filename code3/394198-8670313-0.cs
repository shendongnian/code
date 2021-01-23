    Dictionary<string, Regex> formatDic = new Dictionary<string, Regex>();
    foreach(XElement curFormat in formats)
    {
         formats.Add(
             curFomat.Attribute("NAME"), 
             new Regex(curFomat.Attribute("FILEFORMAT"), RegexOptions.Compiled));
    }
    foreach(FileInfo curFile in dir.GetFiles())
    {
        try
        {
        Console.WriteLine(
            "File : {0} is of type : {1}",
            curFile.FullName,
            (from c in formatDic
             where c.Value.IsMatch(curFile.FullName)
             select c.Key).Single());
        }
        catch
        {
            Console.WriteLine("Error occuring on file : {0}", curFile.FullName);
        }
    }
