    class DownloadItem : INotifyPropertyChanged
    {
      public DownloadItem()
      {
        this.DisplayBytesTotal = string.Empty;
        this.Url = string.Empty;
        this.DownloadSpeed = string.Empty;
        this.ErrorMessage = string.Empty;
        this.Name = string.Empty;
        this.ProgressBytesRead = string.Empty;
      }
    
      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      private string name;    
      public string Name
      {
        get => this.name;
        set
        {
          if (value == this.name) return;
          this.name = value;
          OnPropertyChanged();
        }
      }
    
      private string url;    
      public string Url
      {
        get => this.url;
        set
        {
          if (value == this.url) return;
          this.url = value;
          OnPropertyChanged();
        }
      }
    
      private double progress;    
      public double Progress
      {
        get => this.progress;
        set
        {
          this.progress = value;
          OnPropertyChanged();
        }
      }
    
      private bool isOpenAfterDownloadEnabled;    
      public bool IsOpenAfterDownloadEnabled
      {
        get => this.isOpenAfterDownloadEnabled;
        set
        {
          this.isOpenAfterDownloadEnabled = value;
          OnPropertyChanged();
        }
      }
    
      private string progressBytesRead;    
      public string ProgressBytesRead
      {
        get => this.progressBytesRead;
        set
        {
          if (value == this.progressBytesRead) return;
          this.progressBytesRead = value;
          OnPropertyChanged();
        }
      }
    
      private long bytesTotal;    
      public long BytesTotal
      {
        get => this.bytesTotal;
        set
        {
          if (value == this.bytesTotal) return;
          this.bytesTotal = value;
          OnPropertyChanged();
        }
      }
    
      private string displayBytesTotal;    
      public string DisplayBytesTotal
      {
        get => this.displayBytesTotal;
        set
        {
          if (value == this.displayBytesTotal) return;
          this.displayBytesTotal = value;
          OnPropertyChanged();
        }
      }
    
      private string downloadSpeed;    
      public string DownloadSpeed
      {
        get => this.downloadSpeed;
        set
        {
          if (value == this.downloadSpeed) return;
          this.downloadSpeed = value;
          OnPropertyChanged();
        }
      }
    
      private string timeElapsed;    
      public string TimeElapsed
      {
        get => this.timeElapsed;
        set
        {
          if (value == this.timeElapsed) return;
          this.timeElapsed = value;
          OnPropertyChanged();
        }
      }
    
      private string errorMessage;    
      public string ErrorMessage
      {
        get => this.errorMessage;
        set
        {
          if (value == this.errorMessage) return;
          this.errorMessage = value;
          OnPropertyChanged();
        }
      }
    }
