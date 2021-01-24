     namespace example
        {
            public class MyService : IMyService
            {
                public MyService()
                {
                    // on signleton service this only gets invoked once
                }
        
                public void MyMethod()
                {
                    // your imolmentation here 
                }
            }
        }
