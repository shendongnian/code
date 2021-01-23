    [XmlRoot]
    public class ClassToSerialize
    {
      private StringWithOpenAndClosingNodeClass mStringWithOpenAndClosingNode;
      [XmlElement]
      public StringWithOpenAndClosingNodeClass Marker
      {
        get { return mStringWithOpenAndClosingNode ?? new StringWithOpenAndClosingNodeClass(); }
        set { mStringWithOpenAndClosingNode = value; }
      }
    }
    [XmlRoot]
    public class StringWithOpenAndClosingNodeClass
    {
      private string mValue;
      [XmlText]
      public string Value
      {
        get { return mValue ?? string.Empty; }
        set { mValue = value; }
      }
    }
