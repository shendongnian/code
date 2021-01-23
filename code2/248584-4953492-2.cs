    using System;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Data;
    
    namespace TimeEntryService
    {
        [ServiceContract]
        public interface ITimeEntry
        {
            [OperationContract]
            string Ping();    
        }
    }
