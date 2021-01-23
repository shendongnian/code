    public interface ICSIItem {
    
       void Initialize();
       event EventHandler<NotebookAnswerChangedEventArgs> AnswerValueChanged;
       object DataContext { get; set; }
    
    }
