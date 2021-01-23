    StreamReader sr;
    string[] lines;
    string[] logFiles = Directory.GetFiles(@"C:\Logs");
    foreach (string file in logFiles)
    {
        using (StreamReader sr = new StreamReader(file)
        {
            lines = sr.ReadAllLines();
            foreach (string line in lines)
            {        
                if (line.Contains("ACTION:") || line.Contains("INPUT:") || line.Contains("RESULT:"))
                {
                    // Do what you need to here
                }
            }
            
        }
    }
