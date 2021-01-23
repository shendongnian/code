    [DataContract]
    class MyClass1 : ConstructedDataContract
    {
        [DataMember(IsRequired=false)]
        public int Var1 = 5; // This will default to 5, unless it is overwritten by deserializer.
    }
