using System;
using System.Xml;
namespace WriteXmlFile
{
    class Class1
    {
        static void Main(string[] args)
        {
            // first you have to create the xml file to any location
            XmlTextWriter textWriter = new XmlTextWriter("D:\\TestxmlFile.xml", null);
            // to write any things you have to  Opens the document
            textWriter.WriteStartDocument();
                
            
            // Write first element
            textWriter.WriteStartElement("Person");
            textWriter.WriteStartElement("r", "RECORD", "urn:record");
            // Write next element
            textWriter.WriteStartElement("Email", "");
            textWriter.WriteString("DOB");
            textWriter.WriteString("City");
            textWriter.WriteEndElement();
            // WriteChars
            string[] ch = new string[3];
            ch[0] = "a@a.com";
            ch[1] = "YYYY-MM-DD";
            ch[2] = "xyz";
            textWriter.WriteStartElement("Char");
            textWriter.WriteChars(ch, 0, ch.Length);
            textWriter.WriteEndElement();
            // Ends the document.
            textWriter.WriteEndDocument();
            // close writer
            textWriter.Close();
        }
    }
}
Then after that you will find out the desired output
