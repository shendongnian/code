    public class MyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MyItem> FirstTreeCollection 
        { 
            get
            {
                // whatever you need to do here
            }
        }
        public ObservableCollection<MyItem> SecondTreeCollection 
        { 
            get { /* etc */ }
            set { /* etc */ }
        }
        // etc
        public bool Collapsed
        {
            get;
            set;
        }
    }
