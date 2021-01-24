    public class InfiniteAction
    {
        private readonly Action action;
        private CancellationTokenSource cts;
        public InfiniteAction(Action action)
        {
            this.action = action;
        }
        public void Start()
        {
            if (cts == null)
            {
                Thread t = new Thread(() => action());
                t.IsBackground = true;
                cts = new CancellationTokenSource();
                cts.Token.Register(t.Abort);
                t.Start();
            }
        }
        public void Stop()
        {
            if (cts != null)
            {
                cts.Cancel();
                cts.Dispose();
                cts = null;
            }
        }
    }
