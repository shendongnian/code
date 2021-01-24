    public partial class ResponseType
        {
            private int entitylineNumberField;
    
            private string statusCodeField;
    
            private string uid;
    
            private long entityMark;
    
            [XmlElement(ElementName = "entitylineNumber", Namespace = "")]
            public string entitylineNumber
            {
                get
                {
                    return this.entitylineNumberField.ToString();
                }
                set
                {
                    this.entitylineNumberField = int.Parse(value);
                }
            }
    
            /// <remarks/>
            [XmlElement(ElementName = "statusCode", Namespace = "")]
            public string statusCode
            {
                get
                {
                    return this.statusCodeField;
                }
                set
                {
                    this.statusCodeField = value;
                }
            }
    
            [XmlElement(ElementName = "entityUid", Namespace = "")]
            public string Uid
            {
                get
                {
                    return this.uid;
                }
                set
                {
                    this.uid = value;
                }
            }
    
    
            [XmlElement(ElementName = "entityMark", Namespace = "")]
            public string EntityMark
            {
                get
                {
                    return this.entityMark.ToString();
                }
                set
                {
                    this.entityMark = long.Parse(value);
                }
            }
        }
