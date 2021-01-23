    [DataContract(Name = "GenericType")]
    [KnownType(typeof(MyType))]
    public class GenericType<T>
    {
        [DataMember]
        public List<T> Data
        {
            get { return data; }
            set { data = value; }
        }
    }
