    class Result : INotifyPropertyChanged
    {
      private string c1;
      public string C1
      {
        get => this.c1;
        set
        {
          this.c1 = value;
          OnPropertyChanged();
          this.HasChanegs = true;
        }
      }
      private string c2;
      public string C2
      {
        get => this.c2;
        set
        {
          this.c2 = value;
          OnPropertyChanged();
          this.HasChanegs = true;
        }
      }
    
      private bool hasChanges;
      public string HasChanges
      {
        get => this.hasChanges;
        set
        {
          this.hasChanges = value;
          OnPropertyChanged();
         }
       }
    }
