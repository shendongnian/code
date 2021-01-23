    [PropertyChanged.ImplementPropertyChanged]
    public class MyViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
    }
