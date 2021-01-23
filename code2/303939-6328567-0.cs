    using System;
    using System.Xml;
    
    namespace ConsoleApplication7
    {
        class Program
        {
            static void Main(string[] args)
            {
                var document = new XmlDocument();
                document.Load("web.config");
    
                var element = document.SelectSingleNode("//compilation[@defaultLanguage = 'c#' and @debug = 'true']");
    
                var comment = document.CreateComment(element.OuterXml);
    
                element.ParentNode.ReplaceChild(comment, element);
    
                document.Save("web.config2");
    
                var document2 = new XmlDocument();
                document2.Load("web.config2");
    
                var comment2 = document2.SelectSingleNode("//system.web/comment()");
                var newNode = document2.CreateDocumentFragment();
                newNode.InnerXml = comment2.InnerText;
                comment2.ParentNode.ReplaceChild(newNode, comment2);
                document2.Save("web.config3");
    
                Console.ReadKey();
            }
        }
    }
