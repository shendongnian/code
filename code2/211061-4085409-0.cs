    using System;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    
    class Application
    {
    static void Main(string[] args) {
    
    Stream s = 
       Assembly.GetExecutingAssembly().GetManifestResourceStream("File1.xml");
    
    XmlDocument xdoc = new XmlDocument();
    
    StreamReader reader = new StreamReader(s);
    
    xdoc.LoadXml(reader.ReadToEnd());
    
    reader.Close();
    
    }
    }
