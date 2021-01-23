    [XmlRoot("config")]
    public class SourceConfig
    {
       public SourceConfig() {
          Description = String.Empty;
          HelpLink = String.Empty;
          Parameters = new List<ParamDetails>(); 
       }
    
       public string Description { get; set; }
       public string HelpLink { get; set; }
       [XmlElement("param")]
       public List<ParamDetails> Parameters { get; set; }
    }
    
    public class ParamDetails {
       [XmlAttribute("name")]
       public string name;
       [XmlAttribute("value")]
       public string value;
    }
    
    static class Program {
       static void Main() {
          XmlSerializer ser1 = new XmlSerializer(typeof(SourceConfig));
          SourceConfig list1 = new SourceConfig();
          list1.Description = "Test Desc";
          list1.HelpLink = String.Empty;
          list1.Parameters.Add(new ParamDetails { name = "param1", value = "1" });
          list1.Parameters.Add(new ParamDetails { name = "param2", value = "2" });
          ser1.Serialize(Console.Out, list1);
       }
    }
