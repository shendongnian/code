    public class Consumer
    {
        public event EventHandler Received;
        public virtual void OnReceived()
        {
            Received?.Invoke(this, EventArgs.Empty);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mutex = new Mutex();
            var consumer =  new Consumer();
            consumer.Received += (model, ea) =>
            {
                try
                {
                    mutex.WaitOne();
                    var id = Guid.NewGuid().ToString();
                    Console.WriteLine($"Start mutex {id}");
                    Console.WriteLine($"Mutex finished {id}");
                    Console.WriteLine($"Start sleep {id}");
                    if ( new Random().Next(10000)  % 2 == 0) // randomly sleep, that your condition
                    {
                        Thread.Sleep(3000); // <=== SLEEP
                    }
                    Console.WriteLine($"Sleep finished {id}");
                }
                catch (Exception ex)
                {
                    mutex.ReleaseMutex(); // this is where you release, if something goes wrong
                }
                finally
                {
                    mutex.ReleaseMutex();// always release it
                }
            };
            Parallel.For(0, 10, t =>   //running 10 threads in parallel and stops all if the condition is true
            {
                consumer.OnReceived();
            });
            Console.ReadLine();
        }
    }
