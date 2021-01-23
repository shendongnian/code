    public void GetModelTypeResponse(object sender, DownloadStringCompletedEventArgs e)
    {
        var webException = e.Error as WebException;
        if (webException != null && 
            webException.Status == WebExceptionStatus.NameResolutionFailure)
        {
            // log
            return; // ignore
        }
        // proceed
        ..
    }
