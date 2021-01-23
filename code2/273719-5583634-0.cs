    [ServiceContract]
    public interface IServiceBase
    {
        [OperationContract]
        void Method_A();
        [OperationContract]
        void Method_B();
    }
    [ServiceContract]
    public interface IService1 : IServiceBase
    {
        [OperationContract]
        void Method_X1();
    }
    [ServiceContract]
    public interface IService2 : IServiceBase
    {
        [OperationContract]
        void Method_X2();
    }
    public abstract class ServiceBase : IServiceBase
    {
        void Method_A()
        {
            ... implementation here ...
        }
        void Method_B()
        {
            ... implementation here ...
        }
    }
    public class Service1 : ServiceBase, IService1
    {
        void Method_X1()
        {
            ... implementation here ...
        }
    }
    public class Service2 : ServiceBase, IService2
    {
        void Method_X2()
        {
            ... implementation here ...
        }
    }
