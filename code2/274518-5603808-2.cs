    public class MainVm : INotifyPropertyChanged
    {
        protected void OnPropertyChanged(string porpName)
        {
            var temp = PropertyChanged;
            if (temp != null)
                temp(this, new PropertyChangedEventArgs(porpName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public string FullName
        {
            get { return "Hello world"; }
        }
    }
