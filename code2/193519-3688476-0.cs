    public class LogEntry
    {
         private String _source = String.Empty;
         private String _destination = String.Empty;
         private String _result = String.Empty;
         private String _time = String.Empty;
    
         public String Source
         {
             get { return _source; }
             set { _source = value; }
         }
    
         public String Destination
         {
                get { return _source; }
                set { _source = value; }
         }
    
         public String Result
         {
             get { return _source; }
             set { _source = value; }
         }
    
         public String Time
         {
             get { return _source; }
             set { _source = value; }
         }
    
         public LogEntry()
         {
         }
    
         public LogEntry( String source, String destination, String result, String time )
         {
             _source = source;
             _destination = destination;
             _result = result;
             _time = time;
         }
        public LogEntry( String[] args )
        {
            _source = args[0];
            _destination = args[1];
            _result = args[2];
            _time = args[3];
        }
      }
