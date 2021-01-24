    namespace Device.ServiceContract
    {
        [ServiceContract(Namespace = "http://Device.Service", CallbackContract = typeof(IDeviceServiceCallback))]
        public interface IDeviceService
        {
            [OperationContract]
            [ServiceKnownType(typeof(SessionBase))]
            ISessionBase CreateSession(Uin16 id);
        }
    }
