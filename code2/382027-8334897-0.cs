    public class MyViewModel : INotifyPropertyChanged
    {
       public List<MyObject> ComboListObjects
        { 
            get{
                return new List<MyObject>();  // <-- fill this
            }
        }
        private MyObject _selectedItem = null;
        public MyObject ComboSelection
        {
            get { return _selectedItem; }
            set {
                _selectedItem = value;
                NotifyPropertyChanged("ComboSelection");
            }
        }
    }
