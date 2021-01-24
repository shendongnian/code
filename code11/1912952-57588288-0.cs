    public class ViewModel : INotifyPropertyChanged
    {
        private List<ssearch> _items;
        public List<ssearch> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged(); }
        }
        private static ViewModel _instance = new ViewModel();
        public static ViewModel Instance { get { return _instance; } }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
