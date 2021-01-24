        public class TaskViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public string Task
        {
            get
            {
                return _Task;
            }
            set
            {
                _Task = value;
                OnPropertyChanged();
            }
        }
        private string _Task;
    }
