    using System;
    using System.Xml;
    
    class Test
    {
        static void Main() 
        {
            XmlDocument testDoc = new XmlDocument();
            testDoc.PreserveWhitespace = true;
            testDoc.Load("Test.xml");
            testDoc.Save("Output.xml");
        }
    }
