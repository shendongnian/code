    [AfterPropertySetFilter(typeof(NotifyPropertyChanged))]
    public class Foo : INotifyPropertyChanged
    {
        public virtual int Property1 { get; set; }
    
        public virtual int Property2 { get; set; }
    
        public virtual int Property3 { get; set; }
    
        public event PropertyChangedEventHandler PropertyChanged;
    }
