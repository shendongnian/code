    string directory = @"C:\";
    string[] filePath = Directory.GetFiles(directory, "*.txt", SearchOption.AllDirectories);
    Dictionary<string, DateTime> dic = new Dictionary<string, DateTime>();
    foreach (string CurrentPath in filePath)
    {
        string Content = File.ReadAllText(@CurrentPath);
        string loadedDate = DateTime.ParseExact(Content.Substring(9, 8), "yyyyMMdd",
                        CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
        DateTime Datevalue = DateTime.Parse(loadedDate);
    
        dic.Add(Path.GetFileName(CurrentPath), Datevalue);
    }
