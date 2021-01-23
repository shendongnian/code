    public class ServiceProxy : ClientBase<IService>
    {
        public ServiceProxy()
            : base(new ServiceEndpoint(ContractDescription.GetContract(typeof(IService)),
                new NetNamedPipeBinding(), new EndpointAddress("net.pipe://localhost/MyAppNameThatNobodyElseWillUse")))
        {
     
        }
        public void InvokeHelloWorld()
        {
            Channel.HelloWorld();
        }
    }
