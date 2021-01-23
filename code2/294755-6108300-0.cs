    private void DoAsyncProcessingReportResult(IAsyncResult iar)
    {
        AsyncResult ar = (AsyncResult)iar;
        // map this to your delegate (take mine as an example)
        Func<RemoteDirectoryInfo> LoadProcessingReport =
              (Func<RemoteDirectoryInfo>)ar.AsyncDelegate;
    
        // Then get your answer from calling the EndInvoke
        _Directory = LoadProcessingReport.EndInvoke(ar);
    }
