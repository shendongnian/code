    public class InfiniteAction
    {
        private readonly Action action;
        private CancellationTokenSource cts;
        private Thread thread;
        public InfiniteAction(Action action) => this.action = action;
        public void Join() => thread?.Join();
        public void Start()
        {
            if (cts == null)
            {
                cts = new CancellationTokenSource();
                thread = new Thread(() => action());
                thread.IsBackground = true;
                thread.Start();
                cts.Token.Register(thread.Abort);
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
