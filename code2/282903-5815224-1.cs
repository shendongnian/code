    namespace MyNamespace // <-- this is the name you choose when you 
    {                     //     added the web reference
        public class MyService : SoapHttpClientProtocol
        {
             // synchronous execution
             public void DoSomething()
             {
             }
             // async execution
             public void DoSomethingAsync()
             {
             }
             // callback event for async execution
             public event DoSomethingCompletedEventHandler DoSomethingCompleted;
         }
    }
