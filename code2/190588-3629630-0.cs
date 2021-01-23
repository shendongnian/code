    using Jolt;
    using System.Xml.Linq;
    void CopyXmlDocComments(Assembly sourceAssembly)
    {
        XDocument newDocComments = new XDocument();
        XmlDocCommentReader reader = new XmlDocCommentReader(sourceAssembly);
        foreach(Type t in sourceAssembly.GetTypes())  // implement type filter here
        {
            newDocComments.Add(reader.GetComments(t));
        }
        newDocComments.Save("newAssemblyName.dll.xml");
    }
