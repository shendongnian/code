    public interface IHost : INotifyPropertyChanged
    {
        string HostType { get; }
        string Hostname { get; set; }
    }
    public class HistoryItem : IHost
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string HostType => "History";
        public string Hostname { get; set; }
    }
    public class FavoriteItem : IHost
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string HostType => "Favorites";
        public string Hostname { get; set; }
        //other properties....
    }
