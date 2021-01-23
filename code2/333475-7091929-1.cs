    public sealed class ViewModel : INotifyPropertyChanged
    {
      public ObservableCollection<Album> Albums {get;set;}
      public Album SelectedAlbum {get;set;} // implement INPC for this property
    }
