c#
using System;
using System.Collections.Generic;
using System.Xml;
namespace XPath
{
    class MainClass
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(".... your file");
            // Xpaths
            XmlNode root = doc.DocumentElement;
            // Xpaths
            XmlNode root = doc.DocumentElement;
            XmlNodeList xmlFirstNameNodeList = root.SelectNodes("//html/head/meta[@name='firstname']");
            XmlNodeList xmlLastNameNodeList = root.SelectNodes("//html/head/meta[@name='lastname']");
            List<String> authors = new List<String>();
            for(int i=0; i<xmlFirstNameNodeList.Count; i++) {
                authors.Add(xmlFirstNameNodeList[i].Attributes["content"].Value + " " + xmlLastNameNodeList[i].Attributes["content"].Value);
            }
            Console.ReadKey();
        }
    }
}
The content of List authors:
c#
authors[0] = "Eddard Stark"
authors[1] = "Tywin Lannister"
authors[2] = "Jon Snow"
