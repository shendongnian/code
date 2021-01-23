     [ServiceContract]
        public interface IService
        {
            [OperationContract]
            [WebInvoke(UriTemplate = "ProcessMessage")]
            AResponse ProcessMessage(ARequest content);
        }
