    public interface IHost : INotifyPropertyChanged
    {
        string HostType { get; }
        string Hostname { get; set; }
        string DisplayText { get; set; }
    }
    public class HistoryItem : IHost
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string HostType => "History";
        public string Hostname { get; set; }
        public string DisplayText => Hostname;
    }
    public class FavoriteItem : IHost
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string HostType => "Favorites";
        public string Hostname { get; set; }
        public string Description { get; set; }
        public string DisplayText => Description == null ? Hostname : $"{Description} | {Hostname}";
        //other properties....
    }
