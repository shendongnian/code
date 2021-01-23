    public delegate void AnswerValueChangedEventHandler(
      object sender, 
      NotebookAnswerChangedEventArgs e);
    public interface ICSIItem {
      void Initialize();
      event AnswerValueChangedEventHandler AnswerValueChanged;
      object DataContext { get; set; }
    }
