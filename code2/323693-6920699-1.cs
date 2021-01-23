    using System;
    using System.ServiceModel;
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;
    
    [ServiceContract]
    interface TestInterface
    {
        [OperationContract]
        string TestAsXML(string extra);
    
        [OperationContract]
        string TestAsJSON(string extra);
    }
