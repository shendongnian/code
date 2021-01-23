    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ServiceModel;
    
    namespace Service
    {
        [ServiceContract(Name = "EchoContract", Namespace = "http://samples.microsoft.com/ServiceModel/Relay/")]
        public interface IEchoContract
        {
            [OperationContract]
            string Echo(string text);
        }
    }
