    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        public string GivenNames { get; set; }
    }
