    public class MainClass : IMainClass  
        private readonly ILogger logger;
        private readonly IDatabase db;
    
        public MainClass(ILogger logger, IDatabase db) {
            this.logger = logger;  
            this.db = db;
        }
    
        public void AddDetails(Data data) {
            //do some business operations 
            db.Add(data);
            logger.Information("added");
        }
    }
