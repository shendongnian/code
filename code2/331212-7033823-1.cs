    public class Employee : INotifyPropertyChanged
    {
        private bool m_isChecked;
        public bool IsChecked
        {
            get { return m_isChecked; }
            set
            {
                m_isChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }
        // Etc..
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
