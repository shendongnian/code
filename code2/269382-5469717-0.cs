    public class Method
    {
      [XmlAttribute()]
      public int ID {get;set;}
    
      [XmlAttribute()]
      public string Cmd {get;set;}
    
      public string Name {get;set;}
      public int Age {get;set;}
      public string City {get;set;}
      public string Country {get;set;}
    }
    
    public class Batch
    {
      public Method Method { get; set; }
    }
    
    public static string ToXml(object Doc)
    {
      try
      {
        // Save to XML string
        XmlSerializer ser = new XmlSerializer(Doc.GetType());
        var sb = new StringBuilder();
        using (var writer = XmlWriter.Create(sb))
        {
          ser.Serialize(writer, Doc);
        }
        return sb.ToString();
      }
      catch (Exception ex)
      { // Weird!
        ProcessException();
      }
    }
    
    var batch = new Batch();
    batch.Method = new Method { ID=..., Cmd=..., ...};
    
    var xml = ToXml(batch);
