    public partial class Form1 : Form
    {
        private volatile int count;
        private readonly int total;
    
        public Form1()
        {
            InitializeComponent();
    
            var urls = new List<string> { "http://something.com", "http://another.com" };
            total = urls.Count;
    
            // Execute the Parallel loop in a thread from the threadpool, 
            // in order not to block the UI thread.
            ThreadPool.QueueUserWorkItem(o =>
            {
                Parallel.ForEach(urls, x => MakeRequest(x));
            });
    
            // other UI stuff here?
        }
    
        public void MakeRequest(string url)
        {
            // code for web request here...
    
            int newCount = Interlocked.Increment(ref count);
            Invoke(new Action(() => progressBar1.Value = (100 * newCount) / total));
        }
    }
