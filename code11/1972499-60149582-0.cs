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
