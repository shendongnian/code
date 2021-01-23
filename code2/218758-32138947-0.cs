    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://yournamespace.com")]
    public partial class YourObject
    {
        private long sessionTimeoutInSecondsField;
        private bool sessionTimeoutInSecondsFieldSpecified;
        
        public long sessionTimeoutInSeconds
        {
            get
            {
                return this.sessionTimeoutInSecondsField;
            }
            set
            {
                this.sessionTimeoutInSecondsField = value;
            }
        }
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool sessionTimeoutInSecondsSpecified
        {
            get
            {
                return this.sessionTimeoutInSecondsFieldSpecified;
            }
            set
            {
                this.sessionTimeoutInSecondsFieldSpecified = value;
            }
        }
    }
