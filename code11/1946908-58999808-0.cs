    public class AlertService   
    {
        private readonly IAlertDAO storage;
    
        //Constructor
        public AlertService(IAlertDAO alert)
        {
            storage = alert;
        }
    
        public Guid RaiseAlert()
        {
            return this.storage.AddAlert(DateTime.Now);
        }
    
        public DateTime GetAlertTime(Guid id)
        {
            return this.storage.GetAlert(id);
        }
    
        static void Main(string[] args)
        {
            IAlertDAO alertDao = new AlertDAO();
            AlertService alert = new AlertService(alertDao);
            Guid id = alert.RaiseAlert();
            Console.WriteLine(alert.GetAlertTime(id));
            Console.ReadKey();
        }
    }
    
    public class AlertDAO : IAlertDAO
    {
        private readonly Dictionary<Guid, DateTime> alerts = new Dictionary<Guid, DateTime>();
    
        public Guid AddAlert(DateTime time)
        {
            Guid id = Guid.NewGuid();
            this.alerts.Add(id, time);
            return id;
        }
    
        public DateTime GetAlert(Guid id)
        {
            return this.alerts[id];
        }   
    }
    
    public interface IAlertDAO
    {
        Guid AddAlert(DateTime time);
        DateTime GetAlert(Guid id);
    } 
