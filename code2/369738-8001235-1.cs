      [ServiceContract]
      public interface ILGSMapServer {
        
        [OperationContract( AsyncPattern = true )]
        IAsyncResult BeginGetLatitudes( AsyncCallback callback, object context );
        List<double> EndGetLatitudes( IAsyncResult result );
        }
