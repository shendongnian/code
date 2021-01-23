        string[] lines = File.ReadAllLines(sourcePath);
        string ErrorLog="";
        errorLinesTolog=errorLinesTolog.Remove(0, 1);
        foreach (var line in errorLinesTolog.Split(','))
        {
            ErrorLog += lines[int.Parse(line)-1] + Environment.NewLine;
        }
        System.IO.File.WriteAllText(ResultPath, ErrorLog);
    }
