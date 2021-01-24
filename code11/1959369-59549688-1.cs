    using System;
    using System.Xml;
     class MyScript
        {
            public void ExecuteAFunction()
            {
                string path = "D:\\t.xml";
                XmlDocument document = new XmlDocument();
                document.Load(path);
                Console.WriteLine(document.LastChild.InnerXml);
                Console.ReadKey();
    
    
            }
        }
