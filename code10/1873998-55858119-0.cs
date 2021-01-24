    public sealed class MyThreadBase
    {
        private ObservableCollection<object> MyDevices;
        public MyThreadBase(ObservableCollection<object> deviceList)
        {
            MyDevices = deviceList;
            MyDevices.PropertyChanged += MyDevices_PropertyChanged; // Register listener
        }
        private void MyDevices_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            lock (MyDevices)
            {
                // Do something with the data...
            }
        }
    }
