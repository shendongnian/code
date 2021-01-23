    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.RealTime;
        }
        Thread th;
        DispatcherSynchronizationContext ctx;
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            ctx = new DispatcherSynchronizationContext(this.Dispatcher);
            th = new Thread(Start);
            th.Start();
        }
        int MACRO = 10;
        int TESTS = 10;
        int LOOPS = 50000;
        void Start()
        {
            Thread.CurrentThread.Priority = ThreadPriority.AboveNormal;
            // flush just in case
            for (int i = 0; i < 100; i++)
            {
                ctx.Post(Callback, 9999999);
                this.Dispatcher.BeginInvoke(
                    new Action<object>((object state) => { txt2.Text = state.ToString(); }), 
                        DispatcherPriority.Send, 9999999);                
            }
            Thread.Sleep(1000);
            // results
            List<Tuple<long, long>> results = new List<Tuple<long, long>>();
            // actual test
            for (int x = 0; x < MACRO; x++)
            {
                Stopwatch sw = new Stopwatch();
                // sync context post
                long tick1, tick2;
                for (int i = 0; i < TESTS; i++)
                {
                    sw.Start();
                    for (int j = i; j < LOOPS + i; j++)
                    {
                        ctx.Post(Callback, j);
                    }
                    sw.Stop();
                    Thread.Sleep(1500);
                }
                tick1 = sw.ElapsedTicks;
                // begin invoke
                sw.Reset();
                for (int i = 0; i < TESTS; i++)
                {
                    sw.Start();
                    for (int j = i; j < LOOPS + i; j++)
                    {
                        this.Dispatcher.BeginInvoke(
                            new Action<object>((object state) => { txt2.Text = state.ToString(); }), 
                                DispatcherPriority.Normal, j);
                    }
                    sw.Stop();
                    Thread.Sleep(1500);
                }
                tick2 = sw.ElapsedTicks;
                // store results
                results.Add(new Tuple<long, long>(tick1, tick2));
                // display to make it less boring
                this.Dispatcher.BeginInvoke(new Action(() => { txt3.Text += string.Format("{0} {1}. ", tick1, tick2); }));
                Thread.Sleep(100);                
            }
            StringBuilder sb = new StringBuilder();
            foreach (var res in results)
                sb.AppendLine(string.Format("{0}\t{1}\t{2:0.00}\t{3:0.0%}", 
                    res.Item1, res.Item2, (res.Item1 - res.Item2) / 10000, res.Item2 != 0 ? 1.0 - res.Item1 / (double)res.Item2 : 0.0));
            this.Dispatcher.BeginInvoke(
                new Action(() => { txb1.Text = sb.ToString(); }));                
        }
        void Callback(object state)
        {
            txt1.Text = state.ToString();
        }
    }
