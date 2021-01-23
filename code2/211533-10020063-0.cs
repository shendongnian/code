        [ServiceContract( Namespace="X", Name="TheContract" )]
        public interface IAsyncContractForClientAndService
        {
            [OperationContract]
            Task<TResponse> SendReceiveAsync( TRequest req );
        }
       
        [ServiceBehavior (InstanceContextMode = InstanceContextMode.Single, // (1)
                          // also works with InstanceContextMode.PerSession or PerCall
                          ConcurrencyMode     = ConcurrencyMode.Multiple,   // (2)
                          UseSynchronizationContext = true)]                // (3)
        public MyService : IAsyncContractForClientAndService
        {
            public async Task<TResponse> SendReceiveAsync( TRequest req )
            {
                DoSomethingSynchronous();
                await SomethingAsynchronous(); 
                // await lets other clients call the service here or at any await in
                // subfunctions. Calls from clients execute 'interleaved'.
                return new TResponse( ... );
            }
        }
