    using DevExpress.Xpo.Logger;
    using NLog;
    using System;
    
    namespace Simpax.Xpo.Loggers
    {
        public class XpoNLogLogger: DevExpress.Xpo.Logger.ILogger
        {
            static Logger logger = NLog.LogManager.GetLogger("xpo");
    
            public int Count => int.MaxValue;
    
            public int LostMessageCount => 0;
    
            public virtual bool IsServerActive => true;
    
            public virtual bool Enabled { get; set; } = true;
    
            public int Capacity => int.MaxValue;
    
            public void ClearLog() { }
    
            public virtual void Log(LogMessage message) {
                logger.Debug(message.ToString());
            }
    
            public virtual void Log(LogMessage[] messages) {
                if (!logger.IsDebugEnabled) return;
                foreach (var m in messages)
                    Log(m);
            }
        }
    }
