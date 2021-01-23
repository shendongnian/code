    new XElement("message", new XRaw(myHtmlStringVariable));
    public class XRaw : XText
    {
      public XRaw(string text):base(text){}
      public XRaw(XText text): base(text){}
      public override void WriteTo(System.Xml.XmlWriter writer)
      {
        writer.WriteRaw(this.Value);
      }
    }
