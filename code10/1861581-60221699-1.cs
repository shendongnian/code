        public static void PrintLogs(string logType)
        {
            try
            {
                ILogs _logs = driver.Manage().Logs;
                var browserLogs = _logs.GetLog(logType);
                if (browserLogs.Count > 0)
                {
                    foreach (var log in browserLogs)
                    {
                        //log the message in a file
                        Console.WriteLine(log);
                    }
                }
            }
            catch(Exception e)
            {
                //There are no log types present
                Console.WriteLine(e.ToString());
            }
        
