c#
using System;
using System.Threading;
using System.Threading.Tasks;
					
namespace BeginEndInvokeTest
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // This is just here for setup
            var caller = new AsyncDemo.AsyncMethodCaller(AsyncDemo.Test);
            // This is your 'socket.BeginReceive' call
            var ar = caller.BeginInvoke(3000, AsyncCallback, caller);
            // Wait so the program doesn't exit prematurely
            await Task.Delay(5000);
        }
        static void AsyncCallback(IAsyncResult ar)
        {
            var caller = (AsyncDemo.AsyncMethodCaller) ar.AsyncState;
            try
            {
                // If our exception wouldn't be thrown here (which is impossible), 
                // the program would print "No exception was thrown"
                caller.EndInvoke(ar);
                Console.WriteLine("No exception was thrown");
            }
            catch (Exception)
            {
                Console.WriteLine("Exception encountered");
            }
        }
    }
    public class AsyncDemo
    {
        public static string Test(int callDuration)
        {
            // Simply write something to the console, simulate work 
            // and throw an exception
            Console.WriteLine("Test method begins");
            Thread.Sleep(callDuration);
            throw new Exception("Testing");
        }
        public delegate string AsyncMethodCaller(int callDuration);
    }
}
So in short, you can only catch the Exceptions at the `End...` call, nowhere else.
---
**Edit** to address where does the exception go when it isn't caught.
Honestly, I have no idea where it goes. Further testing and trial n' error gave me nothing. It seems like the whole runtime just crashes. When I didn't catch the exception I get a console out with a stack trace that shows where the exception was thrown (inside the `Test` method, as expected), alongside something I've never seen before: `Unhandled Exception: System.Exception: Testing`.  
There is also a second stack trace saying :
Exception rethrown at [0]:
   at System.Runtime.Remoting.Proxies.RealProxy.EndInvokeHelper(Message reqMsg, Boolean bProxyCase)
   at System.Runtime.Remoting.Proxies.RemotingProxy.Invoke(Object NotUsed, MessageData& msgData)
...
So, yeah, it seems like the runtime crashes when you don't catch it.
**Source:** I cobbled this answer together using [this](https://docs.microsoft.com/en-us/dotnet/api/system.iasyncresult?view=netframework-4.8) Microsoft API documentation. Some further info can be found here as [Calling synchronous methods asynchronously](https://docs.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/calling-synchronous-methods-asynchronously?view=netframework-4.8).
