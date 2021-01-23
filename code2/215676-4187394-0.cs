    public interface ICommand
    {
        bool CanExecute { get; }
        void Execute();
    }
    public class SaveDocumentCommand : ICommand
    {
        public bool CanExecute
        {
            get
            {
                return MainForm.Instance.CurrentDocument.IsDirty;
            }
        }
        public void Execute()
        {
            // Save your document here.
        }
    }
