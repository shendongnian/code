    public class TabData : INotifyPropertyChanged
    {
      public TabData(string header)
      {
        this.Header = header;
      }
    
      public string Header { get; set; }
    
      private string serverAddress;
      public string ServerAddress
      {
        get => this.serverAddress;
        set
        {
          if (value == this.serverAddress) return;
          this.serverAddress = value;
          OnPropertyChanged();
        }
      }
    
      private string username;
      public string Username
      {
        get => this.username;
        set
        {
          if (value == this.username) return;
          this.username = value;
          OnPropertyChanged();
        }
      }
    
      private string password;
      public string Password
      {
        get => this.password;
        set
        {
          if (value == this.password) return;
          this.password = value;
          OnPropertyChanged();
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      [NotifyPropertyChangedInvocator]
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
