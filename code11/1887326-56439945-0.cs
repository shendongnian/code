        [ServiceContract]
        public interface IService1
        {
            [OperationContract]
            [WebInvoke(UriTemplate ="/MyTest",Method ="GET",RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json)]
            CompositeType Test();
        }
    
    
        [DataContract]
        public class CompositeType
        {
            bool boolValue = true;
            string stringValue = "Hello ";
    
            [DataMember]
            public bool BoolValue
            {
                get { return boolValue; }
                set { boolValue = value; }
            }
    
            [DataMember]
            public string StringValue
            {
                get { return stringValue; }
                set { stringValue = value; }
            }
    
    }
