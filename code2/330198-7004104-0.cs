    interface IJobLIstener<T>
    {
      void CopyS3File(S3Location src, T des, Action<Exception> complete)
    }
    
    
    public interface IEvernoteJobListener: IJobLIstener<EvernoteLocation>
    {
    }
