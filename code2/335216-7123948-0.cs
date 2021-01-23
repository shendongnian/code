        private static string logFilePath = string.Empty;
        public static void Log(string logMessage, TextWriter w)
        {
            w.Write( logMessage);
            w.Flush();
        }
        public static void Log(string textLog)
        {
            string directoryString =
          filepath+           @"\Logging";
            Directory.CreateDirectory(directoryString);
            logFilePath = directoryString + "\\" +
              DateTime.Now.ToShortDateString().Replace("/", "") + ".txt";
          
            StreamWriter sw = null;
            if (!File.Exists(logFilePath))
            {
                try
                {
                    sw = File.CreateText(logFilePath);
                }
                finally
                {
                    if (sw != null) sw.Dispose();
                }
            }
            using (StreamWriter w = File.AppendText(logFilePath))
            {
                Log(textLog, w);
                w.Close();
            }
        }
