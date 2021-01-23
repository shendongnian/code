    var ser = new DataContractSerializer(typeof (StaticClass.SomeType));
    var obj = new StaticClass.SomeType {Int = 2};
    ser.WriteObject(stream, obj);
    ...
    
    static class StaticClass
    {
        [DataContract]
        public class SomeType
        {
            [DataMember]
            public int Int { get; set; }
        }
    }
