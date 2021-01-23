    using System.Runtime.Serialization;  // From the System.Runtime.Serialization assembly
    [DataContract]
    public struct JsonObj
    {
        [DataMember]
        public int id;
        [DataMember]
        public string name;
        [DataMember]
        public double[] data;
    }
