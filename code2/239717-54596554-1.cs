    static int iMaxLogLength = 2000; // Probably should be bigger, say 200,000
    static int KeepLines = 5; // minimum of how much of the old log to leave
    public static void ManageLogs(string strFileName)
    {
        try
        {
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Length > iMaxLogLength) // if the log file length is already too long
            {
                int TotalLines = 0;
                    var file = File.ReadAllLines(strFileName);
                    var LineArray = file.ToList();
                    var AmountToCull = (int)(LineArray.Count - KeepLines);
                    var trimmed = LineArray.Skip(AmountToCull).ToList();
                    File.WriteAllLines(strFileName, trimmed);
                    string archiveName = strFileName + "-" + DateTime.Now.ToString("MM-dd-yyyy") + ".zip";
                    File.WriteAllBytes(archiveName, Compression.Zip(string.Join("\n", file)));
            }
    
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to write to logfile : " + ex.Message);
        }
    }
