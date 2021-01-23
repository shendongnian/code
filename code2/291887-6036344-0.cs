    Dispatcher.BeginInvoke(DispatcherPriority.Normal, new UpdateProgressDelegate(UpdateProgress), myProgressData);
    //...
    private delegate void UpdateProgressDelegate(ProgressClass progressClass);
    void UpdateProgress(ProgressClass progressClass)
    {
        progressbar.updateprogress(progressclass);
        progressbar.show(); 
    }
