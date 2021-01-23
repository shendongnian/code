    /// <remarks/>
    //[System.Xml.Serialization.XmlElementAttribute("annotation", typeof(annotation))]
    [System.Xml.Serialization.XmlElementAttribute("Items", typeof(annotation))]
    [System.Xml.Serialization.XmlElementAttribute("import", typeof(import))]
    [System.Xml.Serialization.XmlElementAttribute("include", typeof(include))]
    [System.Xml.Serialization.XmlElementAttribute("redefine", typeof(redefine))]
    public openAttrs[] Items {
        get {
            return this.itemsField;
        }
        set {
            this.itemsField = value;
        }
    }
