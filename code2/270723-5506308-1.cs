    Download dl = new Download { OutFileName = "Test", DoForward = true };
    DownloadContent dlc = new DownloadContent { Data = content };
    dl.Contents = dlc;
    db.session.SaveOrUpdate(dlc);
    db.session.SaveOrUpdate(dl);
