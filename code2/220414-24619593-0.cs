    public class NotifyPropertyChangeClass 
        : INotifyPropertyChanged
    {
        public virtual int SomeInt { get; set; }
        public virtual event PropertyChangedEventHandler PropertyChanged;
    }
