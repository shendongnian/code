    [OperationContract]
            [WebInvoke(RequestFormat =WebMessageFormat.Json,ResponseFormat =WebMessageFormat.Json,BodyStyle =WebMessageBodyStyle.Bare)]
            CompositeType GetDataUsingDataContract(CompositeType composite);
    
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
