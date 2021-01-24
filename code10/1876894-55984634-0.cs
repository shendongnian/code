    static object Lock = new object();
    
    
    
    
    public static void LogFile(string ex)
        {
    lock (Lock) {
            try
            {
                string strPath = @"C:\Log.txt";
                if (!File.Exists(strPath))
                    File.Create(strPath).Dispose();
    
                using (StreamWriter sw = File.AppendText(strPath))
                {
                    // sw.WriteLine("=============Error Logging ===========");
                    sw.WriteLine("===========Start============= " + DateTime.Now);
                    sw.WriteLine("Error Message: " + ex);
                    //sw.WriteLine("Stack Trace: " + ex.StackTrace);
                    sw.WriteLine("===========End============= " + DateTime.Now);
                    sw.WriteLine();
    
                }
            }
            catch
            {
    
            }
        }
    }
