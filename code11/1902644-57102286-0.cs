    public class TemperatureViewModel: INotifyPropertyChanged
    {
        private double _celsius;
        public double Celsius
        {
            get { return _celsius; }
            set {
                if (value != _celsius) {
                    _celsius = value;
                    _fahrenheit = Math.Round(1.8 * value + 32.0, 2);
                    OnPropertyChanged(nameof(Celsius));
                    OnPropertyChanged(nameof(Fahrenheit));
                }
            }
        }
        private double _fahrenheit = 32.0;
        public double Fahrenheit
        {
            get { return _fahrenheit; }
            set {
                if (value != _fahrenheit) {
                    _fahrenheit = value;
                    _celsius = Math.Round((value - 32.0) / 1.8, 2);
                    OnPropertyChanged(nameof(Fahrenheit));
                    OnPropertyChanged(nameof(Celsius));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
