      public class TestClass
        {
            
    
    
            #region Public Method
            public TestClass()
            {
                CLoggerCLI.GetSingleInstnace().NotificationEvent += LoggerCLI_NotificationEvent;
            }
    
            private void LoggerCLI_NotificationEvent(string message)
            {
                Console.WriteLine($"*****{message}****");
            }
    }
'''
