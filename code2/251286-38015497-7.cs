    [DataContract]
    class MyClass1 : ConstructedDataContract
    {
        [DataMember(IsRequired=false)]
        public int Var1 = 5; // This will initialise to 5, and if the field is
                             // included in the serialisation stream, then it 
                             // will be overwritten.
    }
