    public class ViewModel : INotifyPropertyChanged
    {
        private int _number1;
        public int Number1
        {
            get { return _number1; }
            set
            {
                _number1 = value;
                _number2 = 0; //sets the other property to any value...
                OnPropertyChanged();
                OnPropertyChanged(nameof(Number2));
            }
        }
        private int _number2;
        public int Number2
        {
            get { return _number2; }
            set
            {
                _number2 = value;
                _number1 = 0; //sets the other property to any value...
                OnPropertyChanged();
                OnPropertyChanged(nameof(Number1));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
