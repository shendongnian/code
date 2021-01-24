    public class MainWindowViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Property Changed Event Handler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
       private String _minJpValue;
        public String minJpValue {
            get { return _minJpValue; }
            set {
                _minJpValue = value;
                OnPropertyChanged(nameof(minJpValue));
            }
        }
    }
