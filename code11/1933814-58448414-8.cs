    class Program
    {
        static async void First()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{DateTime.Now}| First on Thread: {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(1000);
            }
        }
        static async void Second()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{DateTime.Now}| Second on Thread: {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(500);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello World! on Thread: {Thread.CurrentThread.ManagedThreadId}");
            using (var myThread = new AwaitEnabledThread())
            {
                myThread.Post(First);
                myThread.Post(Second);
                Console.ReadLine();
            }
        }
    }
