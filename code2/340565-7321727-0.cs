    [MessageContract]
    public class SomeClass
    {
        [MessageBodyMember]
        public bool value;
    
        public SomeClass(bool value)
        {
            this.value = value;
        }
    }
