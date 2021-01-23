    private delegate void InvokeUpdateProgressBar(object send, UploadProgressArgs args);
    public void UpdateProgressBar(object send, UploadProgressArgs args)
    {
       if (pbFileProgress.InvokeRequired)
       {
          pbFileProgress.Invoke(
             new InvokeUpdateProgressBar(UpdateProgressBar),
             new object[] { send, args });
       }
       else
       {
          ProgressBarUpdate(args.PercentDone);
       }
    }
