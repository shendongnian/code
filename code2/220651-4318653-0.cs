    void findTotalResults(object sender, DownloadStringCompletedEventArgs e)
    {
        lock (this)
        {
            TaxiCompany t = e.UserState;
            string s = e.Result;
            
            ...
        }
    }
