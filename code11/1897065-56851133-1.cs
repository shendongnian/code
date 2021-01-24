    void ReportProgress(string message)
    {
        //Update the UI to reflect the progress value that is passed back.
        txtProgress.Text=message;
    }
    private async void Start_Button_Click(object sender, RoutedEventArgs e)
    {
        //construct Progress<T>, passing ReportProgress as the Action<T> 
        var progressIndicator = new Progress<int>(ReportProgress);
    
        //load the image list *before* starting the background worker
        var folder=txtPath.Text;
        var imageList=LoadImages(folder);
       //call async method
        int uploads=await UploadPicturesAsync(imageList, progressIndicator);
    }
