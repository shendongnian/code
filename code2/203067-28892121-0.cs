        using System.Diagnostics;
        using System.Threading;
        public static T Profile<T>(Func<T> codeBlock, string description = "")
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            T res = codeBlock();
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            const double thresholdSec = 2;
            double elapsed = ts.TotalSeconds;
            if(elapsed > thresholdSec)
              System.Diagnostics.Debug.Write(description + " code was too slow! It took " +
                 elapsed + " second(s).");
            return res;
        }
