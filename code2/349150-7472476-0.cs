    public string lang {
      get {
        XAttribute x = this.Attribute(XName.Get("lang", XNamespace.Xml.NamespaceName));
        return XTypedServices.ParseValue<string>(x, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
      }
      set { 
        this.SetAttribute(XName.Get("lang", XNamespace.Xml.NamespaceName), value, XmlSchemaType.GetBuiltInSimpleType(XmlTypeCode.String).Datatype);
      }
    }
