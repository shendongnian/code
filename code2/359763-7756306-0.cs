    string path = @"C:\restore\restoredb\";
    IList<String> allFiles = Directory.GetFiles(path).ToList();
    IList<String> fileNames = allFiles.Select(filePath => Path.GetFileName(filePath)).ToList();     
    List<String> filesCreatedInLastMonth = new List<string>();
    DateTime endDate = DateTime.Now;
    DateTime beginDate = endDate.AddMonth(-1);
    foreach (var fileName in fileNames)
    {
        DateTime dt = DateTime.Parse(fileName.Substring(7, 10));
        if ((beginDate <= dt) && (dt <= endDate))
        {
            filesCreatedInLastMonth.Add(fileName);
        }
    }
