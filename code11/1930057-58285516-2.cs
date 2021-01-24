    string directory = @"C:\";
    string[] filePath = Directory.GetFiles(directory, "*.txt", SearchOption.AllDirectories);
    Dictionary<DateTime, string> dic = new Dictionary<DateTime, string>();
    foreach (string CurrentPath in filePath)
    {
        string Content = File.ReadAllText(@CurrentPath);
        string loadedDate = DateTime.ParseExact(Content.Substring(9, 8), "yyyyMMdd",
                        CultureInfo.InvariantCulture).ToString("yyyy/MM/dd");
        DateTime Datevalue = DateTime.Parse(loadedDate);
    
        if(!dic.ContainsKey(Datevalue))
            dic.Add(Datevalue, Path.GetFileName(CurrentPath));
    }
