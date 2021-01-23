            void WriteLog(string wpis, StreamWriter sw)
        {
            lock (LogLock)
            {
                sw.WriteLine(wpis);
                sw.Flush();
            }
        }
