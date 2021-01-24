    public DelegateCommand cmdReset_Click { get; }
    
    public LoggingViewModel(){
      cmdReset_Click = new DelegateCommand(Reset_Click);
    }
    
    public class Log{
       public int ID { get; set; }
       public string PDO { get; set; }
       public string LOCATION { get; set; }
       public string HOSTAME { get; set; }
       public int SEVERITY { get; set; }
       public DateTime TIMESTAMP { get; set; }
       public string MESSAGE { get; set; }
    }
    
    public List<Log> Items { get; set; } = new List<Log>();
    
    private List<Log> GetData(){                
       List<Log> logs = new List<Log>();               
       logs.Add(new Log(){
         PDO = "TEST",
         ID = "TEST",
         //LOCATION = "TEST",
         HOSTAME = "TEST",
         SEVERITY = "TEST",
         TIMESTAMP = "TEST",
         MESSAGE = "TEST",
        });
      }
        return logs;
    }
    
    private void Reset_Click(){
      Items = GetData();
      this.OnPropertyChanged("Items");
    }
