    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.FirstChanceException 
                += FirstChanceException
            // ...rest of your app startup
        }
        private static bool LogFirstChanceExceptions
        {
            get  
            {
                return ConfigurationManager.AppSettings["logFirstChanceExceptions"] 
                                           .Equals(bool.TrueString)
            }
        }
        private static void FirstChanceException(object sender,
                                                 FirstChanceExceptionEventArgs e)
        {
            if (e != null && 
                e.Exception != null &&
                LogFirstChanceExceptions)
            {
                Console.Error.WriteLine("First-chance {0}: {1}",
                                        e.Exception.GetType(), 
                                        e.Exception.Message);
            }
        }
    }
