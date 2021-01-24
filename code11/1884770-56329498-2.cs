c#
using System;
using System.IO;
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
            XmlNodeList xmlNodeList = root.SelectNodes("//html/head/meta[@name='firstname' or @name='lastname']");
            foreach (XmlNode node in xmlNodeList)
            {
                Console.Write(node.Attributes["content"].Value + " ");
                if (node.Attributes["name"].Value.Equals("lastname")) {
                    Console.WriteLine();
                }
            }
            Console.ReadKey();
        }
    }
}
output:
Eddard Stark 
Tywin Lannister 
Jon Snow 
