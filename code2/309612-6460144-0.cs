    public event EventHandler<CloseRequestedEventArgs> CloseRequested;
    
    protected virtual void OnCloseRequested(bool? dialogResult)
    {
        var handler = CloseRequested;
        if (handler != null)
            handler(this, new CloseRequestedEventArgs(dialogResult));
    }
    
    ...
    
    public class CloseRequestedEventargs : EventArgs
    {
        private readonly bool? _dialogResult;
    
        public CloseRequestedEventargs(bool? dialogResult)
        {
            _dialogResult = dialogResult;
        }
    
        public bool DialogResult { get { return _dialogResult; } }
    }
