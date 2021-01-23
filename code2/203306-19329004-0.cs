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
            TimeSpan ts = Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine(elapsedTime);
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
