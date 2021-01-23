    using System.Runtime.Serialization;
    
    [DataContract]
    class MyJSONObject
    {
        [DataMember(Name="property1")]
        public int Property1
        {
            get;
            set;
        }
        [DataMember(Name = "property2")]
        public int Property2
        {
            get;
            set;
        }
    }   
