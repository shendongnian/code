    [ServiceContract(Namespace ="MyNamespace")]
    public interface IDeviceService
    {
        [OperationContract]
        string GetDevices();
    }
