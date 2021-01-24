    protected override void OnClosing(CancelEventArgs e)
    {
    
                e.Cancel = false; //prevent your application to shutdown
                Camera.Stop(); //stop your camera
                base.OnClosing(e);
    
    }
    protected override void OnClosed(EventArgs e)
    {
                base.OnClosed(e);
                Application.Current.Shutdown(); //then shutdown again
    }
