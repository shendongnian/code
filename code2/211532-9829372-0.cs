        [ServiceContract( Namespace="X", Name="TheContract" )]
        public interface IClientContractAsynchronous
        {
            [OperationContract]
            Task<TResponse> SendReceiveAsync( TRequest req );
        }
        [ServiceContract( Namespace="X", Name="TheContract" )]
        public interface IServiceContractSynchronous
        {
            [OperationContract]
            TResponse SendReceive( TRequest req );
        }
        
