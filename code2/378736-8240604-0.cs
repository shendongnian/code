    private void SomeMethodRunningOnAnotherThread()
    {
        // ... perform some operations
        
        // Update the UI
        UpdateUI();
        // ... perform more operations
    }
    private void UpdateUI()
    {
        // Make sure we're running on the UI thread
        if (!CheckAccess())
        {
            this.Dispatcher.BeginInvoke(new Action(UpdateUI));
            return;
        }
        // Disable some control
        this.SomeControl.IsEnabled = false;
    }
