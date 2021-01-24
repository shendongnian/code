    public class UtilityClass : IDisposable
    {
        private readonly System.Timers.Timer _Timer;
    
        public UtilityClass()
        {
            _Timer = new System.Timers.Timer(TimeSpan.FromSeconds(10).TotalMilliseconds);
            _Timer.Enabled = true;
            _Timer.Elapsed += (sender, eventArgs) =>
            {
                ExecuteEvery10Sec();
            };
        }
    
        private void ExecuteEvery10Sec()
        {
            Console.WriteLine($"Every 10 sec all at {DateTime.Now}");
        }
    
        public void Dispose()
        {
            _Timer.Dispose();
        }
    }
