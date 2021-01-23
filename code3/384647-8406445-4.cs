    private delegate void InvokeUpdateProgressBar(object send, UploadProgressArgs args);
    private int _PercentDone = -1;
    public void UpdateProgressBar(object send, UploadProgressArgs args)
    {
       if(_PercentDone != args.PercentDone)
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
          _PercentDone = args.PercentDone;
       }
    }
