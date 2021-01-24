        public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child poperty changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    }
