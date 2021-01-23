    public class PositionedObject : IXmlSerializable
    {
    
      public void WriteXml(System.Xml.XmlWriter writer)
      {
            if (  Position != DefaultPosition )
    	      writer.WriteAttributeString("Position", Position);
      }
    }
