    public class Delay
    {
        readonly Timer _timer;
        readonly Action _action;
        private Delay(Action action, double delayMilliseconds)
        {
            _action = action;
            _timer = new Timer(delayMilliseconds);
            _timer.Elapsed += ExecuteCallback;
        }
        void ExecuteCallback(object sender, ElapsedEventArgs e)
        {
            _timer.Stop();
            _timer.Elapsed -= ExecuteCallback;
            _timer.Dispose();
            _action();
        }
        void Begin()
        {
            _timer.Start();
        }
        public static void Invocation(Action action, int delayMilliseconds)
        {
            var delay = new Delay(action, delayMilliseconds);
            delay.Begin();
        }
    }
