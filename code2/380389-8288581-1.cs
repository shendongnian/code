    public class Presenter : INotifyPropertyChanged
    {
        public string MyTextValue { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        /// Create a method here that raises the event that you call from your setters..
    }
