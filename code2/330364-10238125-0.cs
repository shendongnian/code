    protected override void OnInitialized(EventArgs e)
    {
       while (this.CanFocus) { this.Focus(); WPFWaitForPriority.WaitForPriority(DispatcherPriority.Background); }
       base.OnInitialized(e);
    }
  
