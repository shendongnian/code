    DownloadManager.Request request = new DownloadManager.Request(Android.Net.Uri.Parse(url));
    
    request.AllowScanningByMediaScanner();
    request.SetNotificationVisibility(DownloadManager.Request.VisibilityVisibleNotifyCompleted);
    request.SetTitle("Download finish");
    request.SetAllowedOverMetered(true);
    request.SetVisibleInDownloadsUi(true);
    request.SetAllowedOverRoaming(true);
    
    //this file path need dynamic request permission
    //String fileName = URLUtil.GuessFileName(url, contentDisposition, "Downloadfile");
    //request.SetDestinationInExternalPublicDir(Application.Context.GetExternalFilesDir("Download").ToString() , fileName);
    
    DownloadManager downloadManager = DownloadManager.FromContext(this);
    long downloadId = downloadManager.Enqueue(request);
