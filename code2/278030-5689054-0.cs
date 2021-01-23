    [ServiceContract]
    public interface IMyService
    {
        [OperationContract(Name = "Foo")]
        void Foo();
        
        [OperationContract(Name = "FooWithId")]
        void Foo(int id);
    }
