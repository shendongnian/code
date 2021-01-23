    private void ChangeContent()
    {
        if (this.InvokeRequired)
        {
            this.Invoke(new MethodInvoker(ChangeContent));
            return;
        }
        _main.ContentPage.Children.Clear();
        _main.ContentPage.Children.Add(_homeScreen);
    }
