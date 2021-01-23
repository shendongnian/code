    using System.Text;
    using System.Xml;
    using System.Xml.Serialization ;
    namespace ConsoleApplication11
    {
      [XmlRoot("Foo")]
      public class Foo
      {
        public Foo()
        {
          bar = new Bar() ;
          ram = new Ram() ;
        }
        [XmlElement("barId")]
        public Bar bar { get; set; }
        [XmlElement("ramId")]
        public Ram ram { get; set; }
      }
      public class Bar
      {
        [XmlText]
        public int Id { get; set; }
      }
      public class Ram
      {
        [XmlText]
        public int RamId { get; set; }
      }
      class Program
      {
        static int Main( string[] argv )
        {
          XmlSerializer xml = new XmlSerializer( typeof(Foo) ) ;
          XmlWriterSettings settings = new XmlWriterSettings() ;
   
          settings.Indent = true ;
          settings.IndentChars = "  " ;
          settings.Encoding = new UnicodeEncoding( false , false ) ; // little-endian, omit byte order mark
          settings.OmitXmlDeclaration = true ;
          Foo instance = new Foo() ;
          instance.bar.Id = 1234 ;
          instance.ram.RamId = 9876 ;
          StringBuilder sb = new StringBuilder() ;
          using ( XmlWriter writer = XmlWriter.Create( sb , settings ) )
          {
            xml.Serialize(writer, instance ) ;
          }
          string xmlDoc = sb.ToString() ;
          Console.WriteLine(xmlDoc) ;
          return 0;
        }
    
      }
    
    }
