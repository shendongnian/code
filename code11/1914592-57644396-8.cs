    class ViewModel : INotifyPropertyChanged
    {
      private string message;
      public string Message
      {
        get => this.message;
        set
        {
          this.message = value;
          OnPropertyChanged();
        }
      }
    
      ICommand ShowMessageCommand => new RelayCommand(CreateMessage);
    
    
      // Command callback
      private void CreateMessage()
      {
        this.Message = "This is a message for display in the UI";
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
    
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
