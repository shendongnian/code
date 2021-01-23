    private void OnBrowserPostNavigating(object sender, NavigatingEventArgs e)
    {        
        // meaning the link is external, we want to open this outside of our app
        if (!e.Uri.AbsoluteUri.Contains("m.google.com/app/plus"))
        {
            e.Cancel = true;
            WebBrowserTask task = new WebBrowserTask();
            task.URL = e.Uri.AbsoluteUri;
            task.Show();
        }
    }
