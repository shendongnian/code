    using System;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void Main(string[] args)
        {
            XElement element = new XElement( "NodeName" );
            string example = "This is a string\nWith new lines in it\n";
            element.Add( new XText( example ) );
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.CheckCharacters = false;
            settings.NewLineChars = "&#10;";
            XmlWriter writer = XmlWriter.Create(Console.Out, settings);
            element.WriteTo(writer);
            writer.Flush();
        }
    }
    }
