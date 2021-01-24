    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanges([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected void SetPropertyValue<T>(ref T bakingFiled, T value, [CallerMemberName] string proertyName = null)
        {
            bakingFiled = value;
            OnPropertyChanges(proertyName);
        }
    }
    
