    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;
    namespace ClientInfoSample
    {
        [ServiceContract]
        public interface IService
        {
            [OperationContract]
            string GetData(string value);
        }
    }
