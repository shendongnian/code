    using System;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main( string[] args )
            {
                XDocument doc = XDocument.Load( "XMLFile1.xml" );
    
                var authors = doc.Descendants( "Author" );
    
                foreach ( var author in authors )
                {
                    Console.WriteLine( author.Value );
                }
                Console.ReadLine();
            }
        }
    }
