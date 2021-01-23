    public class Hi : ITest
        {
            public void Hello()
            {
                HttpContext.Current.Response.Write("Hi there!");
            }
        }
    
        public class HelloMessage : ITest
        {
            public void Hello()
            {
                HttpContext.Current.Response.Write("Hello there!");
            }
        }
    ITest messenger;
    
    if (User Needs "Hi")
    {
       messenger = new Hi();
    }
    else if (User Needs "Hello")
    {
       messenger = new HelloMessage();
    }
    
    messenger.Hello(); 
