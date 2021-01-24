    static void Main(string[] args) {
        var AnswerQueue = new System.Collections.Concurrent.ConcurrentQueue<string>();
        
        Func<string, string, Task> testFunc = async (f, n) => {
            Console.WriteLine("Starting Action");
            f += n;
            Console.WriteLine(f);
            AnswerQueue.Enqueue(f);
            await Task.Delay(100);
        };
    
        SubscribeToConfigAsync<string>("1", "2", testFunc);
    
        for (int j1 = 0; j1 < 12; ++j1) {
            if (AnswerQueue.TryDequeue(out var ans)) {
                Console.WriteLine($"{DateTime.Now.TimeOfDay}: {ans}");
            }
            Thread.Sleep(1000);
        }
    
        GlobalTimer.Stop();
    
        Console.WriteLine("END");
    }
    
    public static System.Timers.Timer GlobalTimer;
    
    static void SubscribeToConfigAsync<T>(string feature, string name, Func<string, string, Task> action) {
        GlobalTimer = new System.Timers.Timer(2000);
        GlobalTimer.Elapsed += async (sender, e) => await action(feature, name);
        GlobalTimer.Start();
    }
