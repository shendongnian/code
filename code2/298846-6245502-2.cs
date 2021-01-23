    public MainPage()
            {
                InitializeComponent();
                MessageBox.Show("began!");
                ThreadPool.QueueUserWorkItem(o => Run1(AssyncCallback));
                Thread.Sleep(5000);
                MessageBox.Show("outer ended")
            }
    
            public void Run1(AsyncCallback callback)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show("run called"));
                m_request = WebRequest.Create(@"http://localhost:9892/testGet.htm");
                m_request.BeginGetResponse(callback, null);
                Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show("finish"));
            }
