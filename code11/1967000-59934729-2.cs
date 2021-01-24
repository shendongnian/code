    namespace UiService
    {
        using System;
        using System.Runtime.Serialization;
        using System.ServiceModel;
        using ServerChildClassNamespace;
        [ServiceContract(Namespace = "UiService",SessionMode = SessionMode.Required)]
        [ServiceKnownType(typeof(ChildClass))] // On the server side this is an ChildClass, but the client will receive it as a BaseClass.
        public interface IExampleContract
        {
            [OperationContract]
            BaseClass ExampleMethod(BaseClass ExampleArgument);
        }
    }
