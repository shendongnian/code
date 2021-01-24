    public class Device : INotifyPropertyChanged
    {
        public string name {get;set;}
        public ObservableCollection<DeviceInfo> deviceInfos {get;set;}
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) 
    }
    public class DeviceInfo : INotifyPropertyChanged
    {
        public int key {get;set;}
        public values value {get;set;}
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
    public class values : INotifyPropertyChanged
    {
         public string Type {get;set;}
         public string TypeName {get;set;}
         public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
