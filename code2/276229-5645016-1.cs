    public class LoggingInspector : IParameterInspector
    {
        private string service;
        public LoggingInspector(string serviceName){ service = serviceName;}
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState){}
        public object BeforeCall(string operationName, object[] inputs)
        {
          // your logging logic
        }
    }
    
     //Operation Logging attribute - applied to operationcontracts.
     [AttributeUsage(AttributeTargets.Method)]
     public class OperationLoggingAttribute : Attribute, IOperationBehavior
     {
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters){}
        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation){}
        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            if (ConfigurationManager.AppSettings["your_app_config_key"] == "TRUE")
                dispatchOperation.ParameterInspectors.Add(new LoggingInspector(dispatchOperation.Parent.Type.Name));
        }
        public void Validate(OperationDescription operationDescription){}
     }
     
     //Service Loggign attribute - applied to Service contract
    [AttributeUsage(AttributeTargets.Class)]
    public class ServiceLoggingAttribute : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters){}
        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            if (ConfigurationManager.AppSettings["your_app_config_key"] == "TRUE")
                foreach (ServiceEndpoint endpoint in serviceDescription.Endpoints)
                    foreach (OperationDescription operation in endpoint.Contract.Operations)
                        operation.Behaviors.Add(new OperationLoggingAttribute());
        }
        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase){}
    }
