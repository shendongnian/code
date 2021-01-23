    private static string ToXml(Person obj)
    {
      XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
      namespaces.Add(string.Empty, string.Empty);
      string retval = null;
      if (obj != null)
      {
        StringBuilder sb = new StringBuilder();
        using (XmlWriter writer = XmlWriter.Create(sb, new XmlWriterSettings() { OmitXmlDeclaration = true }))
        {
          new XmlSerializer(obj.GetType()).Serialize(writer, obj,namespaces);
        }
        retval = sb.ToString();
      }
      return retval;
    }
