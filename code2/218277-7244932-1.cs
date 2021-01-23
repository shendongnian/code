    namespace Example
    {
    
       public enum Language
       {
         [XmlEnum("en")]
         English,
    
         [XmlEnum("de")]
         Deutsch
       }
    
       public class ExampleClass
       {
    
          private Language? language;
    
          [XmlAttribute("Language")]
          public Language Language
          {
             get { return language ?? Example.Language.English; }
             set { language = value; }
          }
    
          .
          .
          .
       }
    }
