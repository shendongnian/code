    public class MyBehaviorAttribute : Attribute, IServiceBehavior, IOperationBehavior
    {
        //IOperationBehavior
        public void ApplyDispatchBehavior(OperationDescription operationDescription,
                DispatchOperation dispatchOperation)
        {
            dispatchOperation.Invoker = new MyOperationInvoker(dispatchOperation.Invoker);
        }
        public void AddBindingParameters(OperationDescription operationDescription,
                BindingParameterCollection bindingParameters) { /*Do nothing*/ }
        public void ApplyClientBehavior(OperationDescription operationDescription,
                ClientOperation clientOperation) { /*Do nothing*/ }
        public void Validate(OperationDescription operationDescription) { /*Do nothing*/ }
        //IServiceBehavior
        public void Validate(ServiceDescription serviceDescription,
                    ServiceHostBase serviceHostBase) { /*Do nothing*/ }
        public void AddBindingParameters(ServiceDescription serviceDescription,
                    ServiceHostBase serviceHostBase,
                    Collection<ServiceEndpoint> endpoints,
                    BindingParameterCollection bindingParameters) { /*Do nothing*/ }
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription,
                    ServiceHostBase serviceHostBase)
        {
            foreach (ServiceEndpoint endpoint in serviceHostBase.Description.Endpoints)
            {
                foreach (var operation in endpoint.Contract.Operations)
                {
                    operation.Behaviors.Add(this);
                }
            }
        }
