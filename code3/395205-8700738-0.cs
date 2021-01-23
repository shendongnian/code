    using System;
    using System.ServiceModel;
    
    namespace ExperimentConsoleApp
    {
        class Program
        {
            static void Main()
            {
                string endPoint = "http://localhost/service.svc";
    
                string interfaceName = "ExperimentConsoleApp.ITest";
                Type myInterfaceType = Type.GetType(interfaceName);
                var factoryType = typeof(ChannelFactory<>).MakeGenericType(myInterfaceType);
                ChannelFactory factory = Activator.CreateInstance(factoryType, new object[] { new BasicHttpBinding(), new EndpointAddress(endPoint) }) as ChannelFactory;
            }
        }
    
        [ServiceContract]
        public interface ITest
        { }
    }
