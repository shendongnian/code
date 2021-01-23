    public static void LogInfo(string format, params object[] args)
    {
        lock (_logLock)
        {
            using (StreamWriter sw = File.Exists(GetLogPath) ? File.AppendText(GetLogPath()) : File.CreateText(GetLogPath())
            {
                sw.WriteLine(GetTimeStamp() + String.Format(format, args));
            }
        }
    }
