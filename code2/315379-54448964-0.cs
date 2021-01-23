    class MainPageViewModel : INotifyPropertyChanged
    {
        IEnumerable myList;
        public event PropertyChangedEventHandler PropertyChanged;
        public MainPageViewModel()
        {
            MyAsyncMethod()
        }
        public IEnumerable MyList
        {
            set
            {
                if (myList != value)
                {
                    myList = value;
                    
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("MyList"));
                    }
                }
            }
            get
            {
                return myList;
            }
        }
        async void MyAsyncMethod()
        {
            MyList = await DoSomethingAsync();
        }
    }
