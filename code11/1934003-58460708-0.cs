    string patSerial = @"(?<={@BTEST\|)(.*?)(?=\|)";
    string patMeasur = @"(?<={@A-CAP\|\d\|.)(.*?)(?=\{)";
    string LogPath = @"C:\Data\FailedLogs";
    string LogDBSNResult = @"C:\results1.txt";
    
    using (StreamWriter log = new StreamWriter(LogDBSNResult))
    {
        foreach(string fileName in Directory.GetFiles(LogPath))
        {
            string fileContent = File.ReadAllText(fileName);
    
            if (Regex.IsMatch(fileContent, patSerial) && Regex.IsMatch(fileContent, patMeasur))
            {
                string serial = Regex.Match(fileContent, patSerial).Value;
                string measurement = Regex.Match(fileContent, patMeasur).Value;
    
                log.WriteLine($"{serial}, {measurement}");
            }
        }
    }
