        using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using DocumentFormat.OpenXml.Packaging;
    using DocumentFormat.OpenXml.Presentation;
    using DocumentFormat.OpenXml.Drawing;
    public static class PtOpenXmlExtensions
    {
        public static XDocument GetXDocument(this OpenXmlPart part)
        {
            XDocument partXDocument = part.Annotation<XDocument>();
            if (partXDocument != null)
                return partXDocument;
            using (Stream partStream = part.GetStream())
            using (XmlReader partXmlReader = XmlReader.Create(partStream))
                partXDocument = XDocument.Load(partXmlReader);
            part.AddAnnotation(partXDocument);
            return partXDocument;
        }
        public static void PutXDocument(this OpenXmlPart part)
        {
            XDocument partXDocument = part.GetXDocument();
            if (partXDocument != null)
            {
                using (Stream partStream = part.GetStream(FileMode.Create, FileAccess.Write))
                using (XmlWriter partXmlWriter = XmlWriter.Create(partStream))
                    partXDocument.Save(partXmlWriter);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (PresentationDocument presentationDocument = PresentationDocument.Open("test.pptx", true))
            {
                XDocument slideXDoc = presentationDocument.PresentationPart.SlideParts.First().GetXDocument();
                XNamespace p = "http://schemas.openxmlformats.org/presentationml/2006/main";
                XNamespace a = "http://schemas.openxmlformats.org/drawingml/2006/main";
                XElement sh = slideXDoc.Root.Element(p + "cSld").Element(p + "spTree").Elements(p + "sp").First();
                XElement r = sh.Element(p + "txBody").Elements(a + "p").Elements(a + "r").Skip(1).FirstOrDefault();
                Console.WriteLine(">{0}<", r.Element(a + "t").Value);
            } 
        }
    }
