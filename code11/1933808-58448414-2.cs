    // Test program
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            // create your test class
            using (var bla = new TestMyAwaitableThread())
                Console.ReadLine();
        }
    }
---
    // Test class (which is derived from AwaitEnabledThread)
    public class TestMyAwaitableThread : AwaitEnabledThread
    {
        protected override void Run()
        {
            // instead of just running this thread, I'll post two methods
            // So you can see they are "interrupting" each other.
            Post(Run2);
            Post(Run3);
        }
        protected async void Run2()
        {
            while (!Terminated)
            {
                Console.WriteLine($"{DateTime.Now}| Run2 on Thread: {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(1000);
            }
        }
        protected async void Run3()
        {
            while (!Terminated)
            {
                Console.WriteLine($"{DateTime.Now}| Run3 on Thread: {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(500);
            }
        }
    }
