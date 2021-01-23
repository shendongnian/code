    public interface IDbBatchCommand : IDisposable
    {
      void AddToBatch(ParameterCollection parameters);
      void ExecuteBatch(IDbTransaction transaction);
    }
