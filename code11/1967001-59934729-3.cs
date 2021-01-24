    namespace UiService
    {
        using System;
        using System.Runtime.Serialization;
        using System.ServiceModel;
        using ServerChildClassNamespace;
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
        [ServiceKnownType(typeof(ChildClass))] // On the server side this is an ChildClass, but the client will receive it as a BaseClass.
        public sealed class UIServiceImplementation : IExampleContract
        {
    	BaseClass ExampleMethod(BaseClass ExampleArgument);
        }
    }
