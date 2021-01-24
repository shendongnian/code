    public class MyViewModel : INotifyPropertyChanged
    {
        private string _myString;
        public string MyString
        {
            get => _myString;
            set
            {
                _myString = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MyString));
            }
        }
    }
