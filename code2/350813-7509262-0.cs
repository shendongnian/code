    // you don't need to specify PerSession as it is default, but I have for clarity
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class MyService : IMyService
    { 
        public MyService()
        {
            // constructor will be called for each new client session
            // eg fire an Event, log a new client has connected, etc
        }
        // ...
    }
