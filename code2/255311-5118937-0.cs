    using System;
    using System.Linq;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            XDocument doc = XDocument.Load("test.xml");
            foreach (var element in doc.Descendants("key")
                                       .Where(x => (string) x == "jobSteps"))
            {
                Console.WriteLine(element.NextNode);
            }
        }
    }
