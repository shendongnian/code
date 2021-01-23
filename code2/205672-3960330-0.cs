    [DataContract]
    public class SerializeMe
    {
        public SerializeMe(string someString)
        {
            _someString = someString;
        }
        [DataMember]
        private string _someString;
        public string TransformedValue
        {
            get { _someString = TransformToSomething();
                  return _someString; }
            set { _someString = value; }
        }
    }
