    public class Money : INotifyPropertyChanged {
        double _currentMoney;
        public event PropertyChangedEventHandler PropertyChanged;
        public double CurrentMoney 
        { 
             get => _currentMoney;
             set
             {
                 _currentMoney = value;
                 OnPropertyChanged();
             }
        }
        public Money() => CurrentMoney = 1000;
        public int addMoney(double count) {
            CurrentMoney += count;
            return 1;
        }       
    
        public int subMoney(double count) {
            CurrentMoney -= count;
            if (CurrentMoney < 0) { return 100; }
            return 1;
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null) 
        {
            var handle = PropertyChanged;
            handle?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
