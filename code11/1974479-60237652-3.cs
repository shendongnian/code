    public class Document : IDocument
    {
      public Document(string title)
      {
        this.Title = title;
      }
      #region Implementation of IDocument
    
      private string title;
      public string Title { get => this.title; set => this.title = value; }
    
      private bool isSelected;
      public bool IsSelected
      {
        get => this.isSelected;
        set
        {
          this.isSelected = value;
          OnPropertyChanged();
        }
      }
    
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    
      #endregion
    }
