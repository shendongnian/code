    using System.Xml ;
    using System.IO;
    class Program
    {
      static void Main( string[] args )
      {
        using ( Stream inputStream = OpenXmlStream() )
        {
          XmlDocument document = new XmlDocument() ;
          document.Load( inputStream ) ;
          Process( document ) ;
        }
      }
      static Stream OpenXmlStream()
      {
        // provide an input stream for the program
      }
      static void Process( XmlDocument document )
      {
        // do something useful here
      }
    }
