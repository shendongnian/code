C#
bool TaskFinished = false;
and run a while loop where you want to wait until timer is finished.
C#
while(!TaskFinished);
Example:
C#
using System;
using System.Threading;
namespace ConsoleApp1
{
    class Program
    {
        static Timer _timer = null;
        static void Main(string[] args)
        {
            bool TaskFinished = false;
            _timer = new Timer(x =>
            {
                Console.WriteLine("Timer is running");
                TaskFinished = true;
            }, null, 1000, Timeout.Infinite);
            Console.WriteLine("Hello World!");
            while(!TaskFinished);
        }
    }
}
