    public interface IDocument : INotifyPropertyChanged
    {
      string Title { get; set; }
      bool IsSelected { get; set; }
    }
