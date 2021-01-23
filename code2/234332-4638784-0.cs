    public static class Logger
    {
        static TextWriter fs = null;
    
        public static string FileName
        {
          set
          {
            fs = File.CreateText(value);
          }
        }
    
        public static void Log(Exception ex)
        {
          if(fs == null) return;
            ///do logging
        }
    
        public static void Log(string text)
        {
          if(fs == null) return;
            ///do logging
        }
    }
