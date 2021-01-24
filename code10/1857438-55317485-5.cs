    using DevExpress.Xpo.Logger;
    using System;
    
    namespace Simpax.Xpo.Loggers
    {
        public class XpoConsoleLogger : DevExpress.Xpo.Logger.ILogger
        {
            public int Count => int.MaxValue;
    
            public int LostMessageCount => 0;
    
            public virtual bool IsServerActive => true;
    
            public virtual bool Enabled { get; set; } = true;
    
            public int Capacity => int.MaxValue;
    
            public void ClearLog() { }
    
            public virtual void Log(LogMessage message) => Console.WriteLine(message.ToString());
    
            public virtual void Log(LogMessage[] messages) {
                foreach (var m in messages)
                    Log(m);
            }
        }
    }
