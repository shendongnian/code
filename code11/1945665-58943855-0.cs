    public class Functions {
        private readonly IOptions<Secrets.ConnectionStrings> connectionStrings;
        private readonly MyEmail myEmail;
        private readonly IMyFunc myFunc;
    
        public Functions(IOptions<Secrets.ConnectionStrings> connectionStrings, MyEmail myEmail, MyFunc MyFunc) {
            this.connectionString = connectionStrings;
            this.myEmail = myEmail;
            this.myFunc = myFunc;
    
            Console.WriteLine("Functions constructor");
        }
        public void ProcessQueueMessage(
            [QueueTrigger("teste")]
            string message,
            ILogger logger
        ) {
            // use my injected stuff
        }
    }
