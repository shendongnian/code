    public class Person : INotifyPropertyChanged
    {
        ….
 
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<ChartData> data;
        public ObservableCollection<ChartData> Data
        {
            get { return data; }
            set
            {
                data = value;
                OnPropertyChanged("Data");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
