    public DelegateCommand cmdReset_Click { get; }
    public ViewModel()
    {
        cmdReset_Click = new DelegateCommand(Reset_Click);
        Items = GetData();
    }
    public class Log
    {
        public int ID { get; set; }
        public string PDO { get; set; }
        public string LOCATION { get; set; }
        public string HOSTAME { get; set; }
        public int SEVERITY { get; set; }
        public DateTime TIMESTAMP { get; set; }
        public string MESSAGE { get; set; }
    }
    public List<Log> Items {get; set;} = new List<Logs>();
    
    private GetData()
    {
       List<Log> logs = new List<Log>();
            logs.Add(new Log()
                {
                    PDO = "test",
                    ID = "number",
                    HOSTAME = "test",
                    SEVERITY = "number",
                    TIMESTAMP = "nate",
                    MESSAGE ="number",
                });
            }
            return logs;
    }
    private void Reset_Click()
    {
        Items = GetData();
    }
