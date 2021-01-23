    protected override void OnClosing(CancelEventArgs e) {
        if (!ControlFacade.CheckIfStkIsLaunched()) {
            e.Cancel = true;
        }
        base.OnClosing(e);
    }
