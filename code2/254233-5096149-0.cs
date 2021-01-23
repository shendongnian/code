    public class LogEntry 
    {
       private List<int> _lines = new List<int>();
       public string LogContent { get;set; }
       public DateTime Time { get;set; }
       public List<int> Lines { get { return _lines; } }
    }
