    public class Demo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
        }
        private string _demoField;
        public string DemoField
        {
            get {return demoField; }
            set
            {
                if (value != demoField)
                {
                    demoField = value;
                    NotifyPropertyChanged("DemoField");
                }
            }
        }
    }
