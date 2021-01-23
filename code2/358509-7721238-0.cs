using System;
using System.IO;
using System.Xml.Serialization;
void Write(root rootInstance)
{
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(root));
    using (FileStream fileStream = new FileStream("filepath.xml", FileMode.Create))
    {
        xmlSerializer.Serialize(fileStream, rootInstance);
    }
}
    public class root
    {
        public ClassA objClassA { get; set; }
    }
    public class ClassA
    {
        public ClassB objClassB { get; set; }
    }
    public class ClassB { }
