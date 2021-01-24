    class Program
    {
        static Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var work1 = new WorkClass();
            var work2 = new WorkClass();
            while (true)
            {
                work1.DoWork(500);
                work2.DoWork(1500);
            }
        }
    }
    public class WorkClass
    {
        public Task DoWork(int delayMs)
        {
            var x = 1;
            int y;
            return Task.Delay(delayMs).ContinueWith(_ =>
            {
                y = 2;
            });
        }
    }
