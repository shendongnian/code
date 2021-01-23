    [ServiceContract]
    public interface IAuthService
    {
        [OperationContract]
        [ApplyDataContractResolver]
        Session Login(string username, string passwordHash);
    }
----------
    using System;
    using System.Data.Objects;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    
    namespace WcfExampleBlog.Services
    {
        public class ApplyDataContractResolverAttribute : Attribute, IOperationBehavior
        {
            #region IOperationBehavior Members
    
            public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
            {
            }
    
            public void ApplyClientBehavior(OperationDescription description, ClientOperation proxy)
            {
                var dataContractSerializerOperationBehavior =
                    description.Behaviors.Find<DataContractSerializerOperationBehavior>();
                dataContractSerializerOperationBehavior.DataContractResolver =
                    new ProxyDataContractResolver();
            }
    
            public void ApplyDispatchBehavior(OperationDescription description, DispatchOperation dispatch)
            {
                var dataContractSerializerOperationBehavior =
                    description.Behaviors.Find<DataContractSerializerOperationBehavior>();
                dataContractSerializerOperationBehavior.DataContractResolver =
                    new ProxyDataContractResolver();
            }
    
            public void Validate(OperationDescription description)
            {
                // Do validation.
            }
    
            #endregion
        }
    }
