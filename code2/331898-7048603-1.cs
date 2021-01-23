    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //...
        private List<Problem> m_list;
        public List<Problem> List
        {
            get { return m_list; }
            set
            {
                m_list = value;
                OnPropertyChanged("List");
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
