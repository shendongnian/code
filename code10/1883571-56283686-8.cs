    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        var setting = (FtpSetting)e.Argument;
        ...
        for (int fileNum = 0; fileNum < setting.Files.Length; fileNum++)
        {
             if (backgroundWorker.CancellationPending)
                 break;
             do
                 ...
                 // use setings.Files[fileNum]
                 // also divide percentage done by setting.Files.Length e.g.
                 double percentage = (100/setting.Files.Length)+fileNum + (read / total * 100);
                 ...
        }
      }
