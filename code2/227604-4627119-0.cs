    public static Boolean CreateLogFile(String message)
            {
                try
          {
                    //string location = @"C://IRPC//myfile1.txt";
                    string location = System.Environment.CurrentDirectory + "\\log " + LogTime + ".txt";
                    if (!File.Exists(location))
                    {
                        FileStream fs;
                        using (fs = new FileStream(location, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                        {
                        }
                        fs.Close();
                    }
    
                    Console.WriteLine(message);
                    //Release the File that is created
                    StreamWriter sw = new StreamWriter(location, true);
                    sw.Write(message + Environment.NewLine);
                    sw.Close();
                    sw = null;
                    return true;
          }
          catch(Exception ex)
                {
                    EventLog.WriteEntry("MIDocShare", "Error in CreateLogFile" + ex.Message.ToString(), EventLogEntryType.Error, 6000);
           return false;
          }
         }
