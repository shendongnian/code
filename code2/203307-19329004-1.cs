    public class AutoStopWatch : Stopwatch, IDisposable {
        public AutoStopWatch() {
            Start();
        }
        public virtual void Dispose() {
            Stop();
        }
    }
    public class AutoStopWatchConsole : AutoStopWatch {
        public override void Dispose() {
            base.Dispose();
            string format = Elapsed.Days > 0 ? "{0} days " : "";
            format += "{1:00}:{2:00}:{3:00}.{4:00}";
            
            Console.WriteLine(format.Format(Elapsed.Days, Elapsed.Hours, Elapsed.Minutes, Elapsed.Seconds, Elapsed.Milliseconds / 10));
        }
    }
    private static void Usage() {
        Console.WriteLine("AutoStopWatch Used: ");
        using (var sw = new AutoStopWatch()) {
            Thread.Sleep(3000);
            Console.WriteLine(sw.Elapsed.ToString("h'h 'm'm 's's'"));
        }
        Console.WriteLine("AutoStopWatchConsole Used: ");
        using (var sw = new AutoStopWatchConsole()) {
            Thread.Sleep(3000);
        }
            
    }
