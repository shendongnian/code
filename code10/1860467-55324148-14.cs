    class TestViewModel : INotifyPropertyChanged
    {
      private RelayCommand downloadCommand;
      private RelayCommand cancelCommand;
      private DownloadItem selectedGame;
      public ObservableCollection<DownloadItem> Games { get; set; }
    
      private Dictionary<DownloadItem, Downloader> DownloaderMap { get; set; }
    
      public TestViewModel()
      {
        this.Games = new ObservableCollection<DownloadItem>();
        this.DownloaderMap = new Dictionary<DownloadItem, Downloader>();
    
        var game1 = new DownloadItem() {Name = "Name1"};
        this.Games.Add(game1);
        this.DownloaderMap.Add(game1, new Downloader());
        var game2 = new DownloadItem() {Name = "Name2"};
        this.Games.Add(game2);
        this.DownloaderMap.Add(game2, new Downloader());
      }
    
      public DownloadItem SelectedGame
      {
        get => selectedGame;
        set
        {
          if (value == selectedGame)
            return;
          selectedGame = value;
          OnPropertyChanged(nameof(SelectedGame));
        }
      }
    
      public RelayCommand DownloadCommand =>
        downloadCommand ??
        (downloadCommand = new RelayCommand((param) => DownloadButton_Click(param), (param) => true));
    
      public RelayCommand CancelCommand =>
        cancelCommand ??
        (cancelCommand = new RelayCommand((param) => CancelButton_Click(param), (param) => true));
    
      private void DownloadButton_Click(object obj)
      {
        if (string.IsNullOrWhiteSpace(this.SelectedGame.Url))
          return;
    
        if (this.DownloaderMap.TryGetValue(this.SelectedGame, out Downloader downloader))
        {
          downloader.DownloadFile(this.SelectedGame);
        }
      }
    
      private void CancelButton_Click(object obj)
      {
        if (!string.IsNullOrWhiteSpace(this.SelectedGame.Url) &&
            this.DownloaderMap.TryGetValue(this.SelectedGame, out Downloader downloader))
        {
          downloader.CancelDownloading();
        }
      }
    }
