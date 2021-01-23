    using System;
    using System.Net;
    using System.Reactive.Linq;//Rx libriary
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    public partial class MainPage : UserControl
    {
        private int count = 0;
        private int error = 0;
        public MainPage()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(StartParallel);
            //ThreadPool.QueueUserWorkItem(StartSequential);
        }
        private void Update(Exception exception)
        {
            if (exception == null)
                Interlocked.Increment(ref count);
            else
                Interlocked.Increment(ref error);
            if ((count%100) == 0)
            {
                int count1 = count;
                Dispatcher.BeginInvoke(() => { textBox.Text = count1.ToString(); });
            }
        }
        private void StartSequential(object o)
        {
            //single instance of  WebClient
            WebClient wc = new WebClient();
            var observer = Observable.FromEventPattern<DownloadStringCompletedEventArgs>(wc, "DownloadStringCompleted")
                .Select(newResult => new {newResult.EventArgs.Error, newResult.EventArgs.Result});
            wc.DownloadStringAsync(new Uri("http://localhost:7123/SilverlightApplication2TestPage.aspx"));
            int i = 0;
            foreach (var nextValue in observer.Next())
            {
                if (i == 10000) break;
                wc.DownloadStringAsync(new Uri("http://localhost:7123/SilverlightApplication2TestPage.aspx"));
                Update(nextValue.Error);
            }
        }
        private void StartParallel(object o)
        {
            for (int i = 0; i < 10000; i++)
            {
                //multiple instance of WebClient
                WebClient t = new WebClient();
                t.DownloadStringCompleted +=
                    (x, nextValue) => Update(nextValue.Error);//order of result sequence is not guaranteed
                t.DownloadStringAsync(new Uri("http://localhost:7123/SilverlightApplication2TestPage.aspx"));
            }
        }
    }
