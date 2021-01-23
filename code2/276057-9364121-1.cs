    foreach (var file in lstFiles)
    {
        string fullFilename = workingDir + "\\" + file;
        using (var browser = new IE(fullFilename))
        {
            //page manipulations...
    
            FileDownloadHandler download = new FileDownloadHandler(fullFilename);
            using (new UseDialogOnce(browser.DialogWatcher, download))
            { //lnkFile.ClickNoWait(); 
                download.WaitUntilFileDownloadDialogIsHandled(15);
                download.WaitUntilDownloadCompleted(150);
            }
        }
        Thread.Sleep(5000);
    }
