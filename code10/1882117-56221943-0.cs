    using System;
    using System.IO;
    
    namespace YourNameSpace.Models
    {
        public class Logger
        {
            private Object Locker { get; set; }
            public string Path { get; set; }
    
            public Logger(string path)
            {
                Locker = new Object();
                Path = path;
            }
    
            public void Log(string message, params object[] args)
            {
                lock (Locker)
                {
                    string messageToLog = string.Format("{0} - {1}", DateTime.Now, string.Format(message, args));
                    string path = System.IO.Path.Combine(Path, string.Format("{0}.txt", DateTime.Today.ToString("yyyyMMdd")));
                    Directory.CreateDirectory(Path);
                    File.AppendAllLines(path, new string[] { messageToLog });
                }
            }
        }
    }
