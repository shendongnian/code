        public class Logger
        {
            public string Message { get; set; }
            public void Log(string message)
            {
                Message = message;
            }
        }
        public class Business
        {
            public void DoWork(int id, Action<string> logAction)
            {
                if (id < 0)
                {
                    logAction("The string is less than zero");
                }
            }
        }
