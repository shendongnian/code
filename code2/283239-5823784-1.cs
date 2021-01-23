    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        //Special handling of started thread
        if (disposing && updateProgress.IsAlive)
        {
            updateProgress.Abort();
        }
        base.Dispose(disposing);
    }
