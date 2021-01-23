    using System.ServiceModel;
    using System.Data;
    
    namespace TimeEntryService
    {
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
        public class WCFTimeEntryService : ITimeEntry
        {
            public string Ping()
            { 
                return "Pong";
            }
        }
    }
