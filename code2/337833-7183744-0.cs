    StreamReader sr;
    string fileContents;
    string[] logFiles = Directory.GetFiles(@"C:\Logs");
    foreach (string file in logFiles)
    {
        using (StreamReader sr = new StreamReader(file)
        {
        
            fileContents = sr.ReadAllText();
            
            if (fileContents.Contains("ACTION:") || fileContents.Contains("INPUT:") || fileContents.Contains("RESULT:"))
            {
                 // Do what you need to here
            }
            
        }
    }
