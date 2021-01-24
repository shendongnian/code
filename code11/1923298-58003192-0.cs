      public partial class Window1 : Window, INotifyPropertyChanged
        {
            private bool testView = true;
            public bool TestView
            {
                get { return testView; }
                set 
                { 
                    if (testView != value)
                    {
                        testView = value;
                        OnPropertyChanged("TestView");
                    }
                }
            }
            public Window1()
            {
                InitializeComponent();
                DataContext = this;
            }
            private void buttonClick(object sender, RoutedEventArgs e)
            {
                TestView = false;
            }
            #region INotify
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            #endregion INotify
        }
