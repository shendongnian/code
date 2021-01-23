    public static void ManageLogs(string strFileName)
    {
        try
        {
            FileInfo fi = new FileInfo(strFileName);
            string OldLog = File.ReadAllText(strFileName);
            string[] EndOfOldLog = new string[KeepLines +2];
            EndOfOldLog[0] = "    ===============    End of old logs    ===============    ";
            if (fi.Length > iMaxLogLength) // if the log file length is already too long
            {
                int TotalLines = 0;
                using (var LogFile = File.Open(strFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    using (var reader = new StreamReader(LogFile))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null) // first just count lines
                        {
                            TotalLines++;
                        }
                        LogFile.Position = 0;
                        int ArrayCounter = 1;
                        int offsetCounter = 0;
                        while ((line = reader.ReadLine()) != null) // then skip to end
                        {
                            if (offsetCounter >= TotalLines - KeepLines)
                            {
                                EndOfOldLog[ArrayCounter] += line;
                                ArrayCounter++;
                            }
    
                            offsetCounter++;
                        }
                        EndOfOldLog[ArrayCounter] += "    ===============    Start of new file    ===============    ";
    
                    }
                    LogFile.Close();
                    File.WriteAllLines(strFileName, EndOfOldLog); // Delete old file and write the last few lines
                    string archiveName = strFileName + "-" + DateTime.Now.ToString("MM-dd-yyyy") + ".zip";
                    File.WriteAllBytes(archiveName, Compression.Zip(OldLog)); //compresses string to byte[] and writes to file
                }
            }
    
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to write to logfile : " + ex.Message);
        }
    }
