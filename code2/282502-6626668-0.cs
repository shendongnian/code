    using System.Reflection;
    using log4net.Core;
    
    namespace MyUtils
    {
        /// <summary>
        /// for getting the log level that belongs to a string
        /// </summary>
        public static class LogLevelMap
        {
            static LevelMap levelMap = new LevelMap();
    
            static LogLevelMap()
            {
                foreach (FieldInfo fieldInfo in typeof(Level).GetFields(BindingFlags.Public | BindingFlags.Static))
                {
                    if (fieldInfo.FieldType == typeof(Level))
                    {
                        levelMap.Add((Level)fieldInfo.GetValue(null));
                    }
                }
            }
    
            public static Level GetLogLevel(string logLevel)
            {
                if (string.IsNullOrWhiteSpace(logLevel))
                {
                    return null;
                }
                else 
                {
                    return levelMap[logLevel]; 
                }
            }
        }
    }
