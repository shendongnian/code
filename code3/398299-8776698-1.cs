    class Program
    {
        static void Main(string[] args)
        {
            var timeBetweenTicks = (long) TimeSpan.FromSeconds(1).TotalMilliseconds;
            System.Threading.Timer timer = null;
            Action onTick = () =>
                {
                    timer.Change(Timeout.Infinite, Timeout.Infinite);
                    try
                    {
                        //Work on tick goes here
                        Console.WriteLine(DateTime.Now);
                    }
                    finally
                    {
                        timer.Change(timeBetweenTicks, timeBetweenTicks);
                    }
                };
            using (timer = new System.Threading.Timer(_ => onTick(), null, 0, timeBetweenTicks))
            {
                Console.ReadKey();
            }
        }
    }
