    namespace Service
    {
        [ServiceContract(Name = "EchoContract", Namespace = "http://samples.microsoft.com/ServiceModel/Relay/")]
        public interface IEchoContract
        {
            [OperationContract]
            string Echo(string text);
        }
        
        [ServiceBehavior(Name = "EchoService", Namespace = "http://samples.microsoft.com/ServiceModel/Relay/")]
        public class EchoService : IEchoContract
        {
            public string Echo(string text)
            {
                Console.WriteLine("Echoing: {0}", text);
                return text;
            }
        }
    }
