    using System;
    using System.Xml;
    
    namespace ConsoleApplication6
    {
        class Program
        {
            private const string XML = "<testfixture name=\"1\" description=\"a\">" +
                                 "<categories>" +
                                 "<category>abc_somewords</category>" +
                                 "</categories>" +
                                 "<test name=\"a\" description=\"a\">" +
                                 "<dependencies>" +
                                 "<dependson typename=\"dependsonthis\" />" +
                                 "</dependencies>" +
                                 "</test>" +
                                 "</testfixture>";
    
            static void Main(string[] args)
            {
                var document = new XmlDocument();
                document.LoadXml(XML);
    
                var testfixture = document.SelectSingleNode("//testfixture[@name = 1]");
    
                var category = testfixture.SelectSingleNode(".//category[contains(text(), 'abc_somewords')]");
    
                if(category != null)
                {
                    var depends = testfixture.SelectSingleNode("//dependson");
                    Console.Out.WriteLine(depends.Attributes["typename"].Value);
                }
                
    
                Console.ReadKey();
            }
        }
    }
