    using System.ServiceModel;
    
    namespace WPFServiceHost1.Service
    {
        [ServiceContract(Namespace = "urn:WPFServiceHost")]
        public interface IClientService
        {
            [OperationContract]
            void ClientNotification(string message);
        }
    }
