    public static XElement GetXElement( this XmlNode node ) {
      XDocument xdoc = new XDocument();
      using ( XmlWriter xmlWriter = xdoc.CreateWriter() ) {
        node.WriteTo( xmlWriter );
      }
      return xdoc.Root;
    }
