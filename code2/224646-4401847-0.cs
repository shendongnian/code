    public class SomeObject: INotifyPropertyChanged
    {
        private bool mTestValue;
        public bool TestValue 
        {
            get {return mTestValue;}
            set {mTestValue = value; NotifyPropertyChanged("TestValue");}
        }
        private string mSomeText;
        public string SomeText
        {
            get {return mSomeText;}
            set {mSomeText = value; NotifyPropertyChanged("SomeText");}
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string name)
        {
            if ((name != null) && (PropertyChanged != null))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
