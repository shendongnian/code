    private void NavigationWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
        ICanClose canClose = this.Content as ICanClose;
        if (canClose != null && !canClose.CanClose())
            e.Cancel = true;
    }
