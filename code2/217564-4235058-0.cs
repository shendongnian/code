    [DataContract,Serializable]
    public class ClassToSerialize
    {
        private bool _mf;
        [NonSerialized]
        public bool IsMf
        { 
            get { return _mf};
            set{ _mf = value;} 
        }
        [DataMember]
        public char PrimaryExc { get; set; }        
    }
