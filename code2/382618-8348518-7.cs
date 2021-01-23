    [OperationContract]
    GenericType<MyType> GetDataUsingDataContract(GenericType<MyType> composite);
    public class Service1 : IService1
    {
        public GenericType<MyType> GetDataUsingDataContract(GenericType<MyType> composite)
        {
            composite.Data.First().Stuff = "Test";
            return composite;
        }
    }
