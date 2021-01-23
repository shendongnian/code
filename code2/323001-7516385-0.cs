    [System.Xml.Serialization.XmlAnyElementAttribute(Namespace="http://www.w3.org/2001/XMLSchema", Order=0)]
    public System.Xml.Linq.XElement Any {
        get {
            return this.anyField;
        }
        set {
            this.anyField = value;
            this.RaisePropertyChanged("Any");
        }
    }
