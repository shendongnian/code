    public partial class SomeWCFServiceClient : IDisposable
    {
      void IDisposable.Dispose()
      {
       if (this.State == CommunicationState.Faulted)
       {
        this.Abort();
       }
       else
       {
         this.Close();
       }
      }
    }
