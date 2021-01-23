    string path = @"C:\restore\restoredb\";            
    IList<String> allFiles = Directory.GetFiles(path).ToList();
    IList<String> fileNames = new List<string>();
    IList<String> filesCreatedInThisMonth = new List<string>();
    fileNames = allFiles.Select(filePath => Path.GetFileName(filePath)).ToList();
                
    if (comboBox1.Text == "Month")
    {
        filesCreatedInThisMonth =
            allFiles.Where(fileName =>
                    {
                        return File.GetCreationTime(fileName).Month
                                == (DateTime.Now.Month == 1 ? 12 : DateTime.Now.Month - 1)
                                &&
                                (DateTime.Now.Year == DateTime.Parse(fileName.Substring(8, 10)).Year);
                    }).ToList();
     }
