    [ServiceContract]
    [ServiceKnownType(typeof(DerivedClass))]
    public interface IService
    {
        [OperationContract]
        BaseClass Foo();
    }
