    namespace SilverlightClient
    {
        public partial class MainPage : UserControl, INotifyPropertyChanged
        {
            public MainPage()
            {
                InitializeComponent();
    
                this.dataContext = this;
            }
    
            void webService_GetRowsCompleted(object sender, GetRowsCompletedEventArgs e)
            {
                MyResults = e.Result.ToList();
    
                tabControl1.UpdateLayout();
            }
            
            protected List<Table1> MyResults
            {
                get { return _myResults; }
                set 
                {
                    if (_myResults != value)
                    {
                        _myResults = value;
                        OnPropertyChanged("MyResults");
                    }
                }
            }
    
            private void OnPropertyChanged(string propertyName) 
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArg(propertyName));
            }
    
            private List<Table1> _myResults = null;
            public event PropertyChangedEventHandler PropertyChanged;
        }
    }
