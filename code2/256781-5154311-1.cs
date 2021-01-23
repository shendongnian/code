    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    
    namespace Service
    {
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
