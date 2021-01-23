    protected override void OnResize(EventArgs e)
    {
        if (AutoSize)
        {
            // Perform your own resizing logic
        }
        else
            OnResize(e);
    }
