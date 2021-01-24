     public static async Task PopulateMetrics()
        {
            await Task.Run(() =>
            {
                if (App.CPUSpeed == 0)
                {
                    var stopWatch = Stopwatch.StartNew();
                    stopWatch.Start();
                    ArrayList al = new ArrayList(); for (int i = 0; i < 5000000; i++) al.Add("hello");
                    App.CPUSpeed = 20000 / stopWatch.ElapsedMilliseconds;
                }
            });
        }
