    namespace SMSNotificationDll
    {
        public class SmsSenderProgram
        {
            public static void Main(string[] args)
            {
                // TODO: Argument validation
                new smsSender().SendMessage(args[0], args[1]);
            }
        }
    }
