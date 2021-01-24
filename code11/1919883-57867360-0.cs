    public class Worker<T>
    {
        public event EventHandler<T> OnCompleted;
        public Worker()
        {}
        public Worker(Func<T> fn, int interval)
        {
            Func = fn;
            Interval = interval;
        }
        public async void Start()
        {
            if (Func == null)
                throw new ArgumentNullException();
            while (true)
            {
                await Task.Delay(Interval);
                try
                {
                    var result = Func();
                    OnCompleted(this, result);
                }
                catch
                {
                    return; // handle
                }
            }
        }
        public Func<T> Func { get; set; }
        public int Interval { get; set; }
    }
