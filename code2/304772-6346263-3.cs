    public class MyViewModel : INotifyPropertyChanged
    {
        private bool isLoading;
        public bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                NotifyPropertyChanged("IsLoading");
            }
        }
        public void SimulateLoading()
        {
            var bw = new BackgroundWorker();
            bw.RunWorkerCompleted += (s, e) => 
                Deployment.Current.Dispatcher.BeginInvoke(
                    () => { IsLoading = false; });
            bw.DoWork += (s, e) =>
            {
                Deployment.Current.Dispatcher.BeginInvoke(() => { IsLoading = true; });
                Thread.Sleep(5000);
            };
            bw.RunWorkerAsync();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
