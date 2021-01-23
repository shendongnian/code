    using System;
    using System.IO;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            var element = new XElement("foo", "\u001f");
            element.Save(new MemoryStream());
        }
    }
