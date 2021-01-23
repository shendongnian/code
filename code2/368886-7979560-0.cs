            DateTime GetCurrentDateTime();
        }
        class ProductionDateTimeManager : IDateTimeManager
        {
            public DateTime GetCurrentDateTime()
            {
                throw new NotImplementedException();
            }
        }
        public class Scheduler
        {
            public Scheduler(IDateTimeManager dateTimeManager)
            {
                this.DateTimeManager = dateTimeManager;
            }
            public Scheduler()
            {
                this.DateTimeManager = new ProductionDateTimeManager();
            }
            public void Execute()
            {
                DateTime current = DateTimeManager.GetCurrentDateTime();
            }
            private IDateTimeManager DateTimeManager { get; set; }
        }
