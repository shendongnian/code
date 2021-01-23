    // The signature for a handler of the ProgressStarted event.
    // title: The title/label for a progress dialog/bar.
    // total: The max progress value.
    public delegate void ProgressStartedType(string title, int total);
    // Raised when progress on a potentially long running process is started.
    public event ProgressStartedType ProgressStarted;
    // Used from derived classes to raise ProgressStarted.
    protected void RaiseProgressStarted(string title, int total) {
        if (ProgressStarted != null) ProgressStarted(title, total);
    }
