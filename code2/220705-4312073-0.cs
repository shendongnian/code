    public class MyClass : INotifyPropertyChanged
    {
        public MyClass(string myString)
        {
            MyString = myString;
        }
        private string m_myString;
        public string MyString
        {
            get
            {
                return m_myString;
            }
            set
            {
                m_myString = value;
                OnPropertyChanged("MyString");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
