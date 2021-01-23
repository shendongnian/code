    public partial class MainPage : UserControl
        {
            private WebRequest m_request;
            public MainPage()
            {
                InitializeComponent();
                MessageBox.Show("began!");
                ThreadPool.QueueUserWorkItem(o => Run1(AssyncCallback));
               
            }
    
            public void Run1(AsyncCallback callback)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show("run called"));
                m_request = WebRequest.Create(@"http://localhost:9892/testGet.htm");
                m_request.BeginGetResponse(callback, null);
                Thread.Sleep(5000);
                Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show("finish"));
            }
    
            public void AssyncCallback(IAsyncResult ar)
            {
                Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show("inside"));
                try {
                    m_request.EndGetResponse(ar);
                    Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show("ok"));
                    
                }
                catch (Exception e) {
                    Deployment.Current.Dispatcher.BeginInvoke(() => MessageBox.Show(e.Message));
                    throw;
                }
            }
        }
