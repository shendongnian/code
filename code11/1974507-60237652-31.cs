    // Important: IsSelected must raise PropertyChanged
    public interface IDocument : INotifyPropertyChanged
    {
      string Title { get; set; }
      bool IsSelected { get; set; }
    }
