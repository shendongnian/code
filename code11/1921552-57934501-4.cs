    [XmlRoot(ElementName = "ResponseDoc", Namespace = "")]
    public partial class ResponseDoc
    {
        private ResponseType[] responseField;
        /// <remarks/>
        [System.Xml.Serialization.XmlElement(ElementName = "response", Namespace = "")]
        public ResponseType[] response
        {
            get
            {
                return this.responseField;
            }
            set
            {
                this.responseField = value;
            }
        }
    }
