    [DataContract]
    public class serviceresponse
    {
        [DataMember]
        public String company;
        [DataMember]
        public String success;
        [DataMember]
        public List<product> products;
        [DataMember]
        public String callbackformore;
        [DataMember]
        public String message;
    }
    [DataContract]
    public class product
    {
        [DataMember(Name = "product")]
        public product2 _product;
    }
    [DataContract(Name = "product")]
    public class product2
    {
        [DataMember]
        public String Name;
        [DataMember]
        public String ExpiryDate;
        [DataMember]
        public String Price;
        [DataMember]
        public String Sizes;
    }
