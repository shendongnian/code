    void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
    {
        using (sender as IDisposable)
        {
            myTextBox.Text = e.Result;
        }
    }
