    [ServiceContract]
    public interface IMyServiceContract
    {
        [OperationContract]
        SomeModel[] GetModels();
    }
