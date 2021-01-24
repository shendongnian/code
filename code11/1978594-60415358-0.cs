    public class ViewModel : INotifyPropertyChanged
    {
        private readonly IRestService _service;
        public ViewModel(IRestService service)
        {
            _service = service;
            GetDataCommand = new RelayCommand(GetData);
        }
        private IEnumerable<string> _items;
        public IEnumerable<string> Items
        {
            get { return _items; }
            set { _items = value; NotifyPropertyChanged(nameof(Items)); }
        }
        public ICommand GetDataCommand { get; }
        private async void GetData(object _)
        {
            var data = await Task.Run(() => _service.GetData());
            Items = data;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
