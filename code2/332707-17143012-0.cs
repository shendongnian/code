    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order=6)]
    public System.DateTime Created {
        get {
            return this.createdField;
        }
        set {
            this.createdField = value;
            this.RaisePropertyChanged("Created");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIgnoreAttribute()]
    public bool CreatedSpecified {
        get {
            return this.createdFieldSpecified;
        }
        set {
            this.createdFieldSpecified = value;
            this.RaisePropertyChanged("CreatedSpecified");
        }
    }
