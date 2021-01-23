    private void webBrowser1_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
    {
        ThreadPool.QueueUserWorkItem(UpdateText);
    }
    private void UpdateText(object o)
    {
        Thread.Sleep(100);
        Dispatcher.BeginInvoke(() =>
        {
            try
            {
                textBlock1.Text = webBrowser1.InvokeScript("eval", "document.title").ToString();
            }
            catch (SystemException)
            {
                ThreadPool.QueueUserWorkItem(UpdateText);
            }
        });
    }
