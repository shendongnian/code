    public partial class MainPage : UserControl, INotifyPropertyChanged
        {
            private ObservableCollection<CustomClass> _myList;
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public ObservableCollection<CustomClass> MyList
            {
                get { return _myList ?? (_myList = new ObservableCollection<CustomClass>()); }
                set
                {
                    _myList = value;
                    RaisePropertyChanged("MyList");
                }
            }
    
            protected void RaisePropertyChanged(string propertyname)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propertyname));
            }
    
            public MainPage()
            {
                InitializeComponent();
                this.DataContext = this;
    
                MyList.Add(new CustomClass() { PropertyToBeWatched = "12"});
                MyList.Add(new CustomClass() { PropertyToBeWatched = "23" });
                MyList.Add(new CustomClass() { PropertyToBeWatched = "24" });
                MyList.Add(new CustomClass() { PropertyToBeWatched = "25" });
                
            }
