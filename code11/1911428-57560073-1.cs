    public class UCEventArgs : EventArgs
    {
        public AccountOpeningPreview UCReference { get; set; }
    
        public UCEventArgs(AccountOpeningPreview reference)
        {
            UCReference = reference;
        }
    }
    
    public event EventHandler<UCEventArgs> Escalate;
    protected virtual void OnEscalate(UCEventArgs e)
    {
        var handler = Escalate;
        if (handler != null)
        {
            handler(this, e);
        }
    }
