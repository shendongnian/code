    public static void CleanupTimeLog(string path)
    {
        var lines = File.ReadAllLines(path);
        var tempFile = Path.GetTempFileName();
        File.WriteAllLines(tempFile, lines);
        var saveList = new List<string>();
        foreach (var line in lines)
        {
            var date = line.Split(' ')[0];
            if (DateTime.TryParse(date, out DateTime result))
            {
                if (result.AddDays(13) >= DateTime.Now.Date)
                {
                    saveList.Add(line);
                }
            }
        }
        File.WriteAllLines(path, saveList);
        File.Delete(tempFile);
    }
