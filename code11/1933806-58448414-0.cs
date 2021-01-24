    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var bla = new TestMyAwaitableThread())
                Console.ReadLine();
        }
    }
---
    public class TestMyAwaitableThread : AwaitEnableThread
    {
        protected override void Run()
        {
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
