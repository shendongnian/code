    public class MyViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MyObj> MyCollection { get; private set; }
        private MyObj _theItem;
        public MyObj TheItem
        {
            get { return _theItem; }
            set
            {
                if (Equals(value, _theItem)) return;
                _theItem= value;
                //Or however else you implement this...
                OnPropertyChanged("TheItem");
                //Do something here.... OR
                //This will trigger a PropertyChangedEvent if you're subscribed internally.
            }
        }
        private string _theValue;
        public string TheValue
        {
            get { return _theValue; }
            set
            {
                if (Equals(value, _theValue)) return;
                _theValue= value;
                OnPropertyChanged("TheValue");
            }
        }
        private int _theIndex;
        public int TheIndex
        {
            get { return _theIndex; }
            set
            {
                if (Equals(value, _theIndex)) return;
                _theIndex = value;
                OnPropertyChanged("TheIndex");
            }
        }
    }
    public class MyObj
    {
        public string PropA { get; set; }
    }
     <!-- Realistically, you'd only want to bind to one of those -->
     <!-- Most likely the SelectedItem for the best usage -->
     <ItemsControl ItemsSource="{Binding Path=MyCollection}"
                   SelectedItem="{Binding Path=TheItem}"
                   SelectedValue="{Binding Path=TheValue}"
                   SelectedIndex="{Binding Path=TheIndex}"
                   />
