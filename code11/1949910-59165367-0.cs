csharp
using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using Xunit;
namespace CodeSnippets.Tests.OpenXml.Wordprocessing
{
    public class LargeCustomXmlPartsTests
    {
        public static readonly XNamespace W = "http://schemas.openxmlformats.org/wordprocessingml/2006/main";
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(20)]
        [InlineData(30)]
        public void CanCreateLargeCustomXmlParts(int size)
        {
            int desiredStreamLength = size * 1024 * 1024;
            string path = $"Document_{size:D2}MB.docm";
            // Create a macro-enabled Word document with a custom XML part having
            // at least the desired size in MB.
            CreateMacroEnabledWordDocument(path, size);
            // Assert that the document does have a custom XML part with at least
            // the desired size.
            using WordprocessingDocument wordDocument = WordprocessingDocument.Open(path, false);
            CustomXmlPart customXmlPart = wordDocument.MainDocumentPart.CustomXmlParts.First();
            using Stream stream = customXmlPart.GetStream(FileMode.Open, FileAccess.Read);
            Assert.True(stream.Length > desiredStreamLength);
        }
        private static void CreateMacroEnabledWordDocument(string path, int size)
        {
            const WordprocessingDocumentType type = WordprocessingDocumentType.MacroEnabledDocument;
            using WordprocessingDocument wordDocument = WordprocessingDocument.Create(path, type);
            // Create a main document part with an empty document.
            MainDocumentPart mainDocumentPart = wordDocument.AddMainDocumentPart();
            WriteRootElement(mainDocumentPart,
                new XElement(W + "document",
                    new XElement(W + "body",
                        new XElement(W + "p"))));
            // Create a custom XML part with the desired size in MB.
            CustomXmlPart customXmlPart = mainDocumentPart.AddCustomXmlPart(CustomXmlPartType.CustomXml);
            WriteRootElement(customXmlPart, CreatePartRootElement(size));
        }
        private static void WriteRootElement(OpenXmlPart part, XElement partRootElement)
        {
            using Stream stream = part.GetStream(FileMode.Create, FileAccess.Write);
            using XmlWriter writer = XmlWriter.Create(stream);
            partRootElement.WriteTo(writer);
        }
        private static XElement CreatePartRootElement(int size)
        {
            var random = new Random();
            return new XElement("root",
                Enumerable.Range(0, size).Select(paragraphIndex =>
                    new XElement("p",
                        new XAttribute("i", paragraphIndex),
                        Enumerable.Range(0, 1000).Select(runIndex =>
                            new XElement("r",
                                new XAttribute("i", runIndex),
                                new XElement("t", CreateRandomString(random)))))));
        }
        private static string CreateRandomString(Random random)
        {
            char[] value = Enumerable
                .Range(0, 930)
                .Select(i => Convert.ToChar(random.Next(33, 125)))
                .ToArray();
            return new string(value);
        }
    }
}
On my Windows 10 notebook, Microsoft Word for Office 365 opens the document with the **30MB** custom XML part without any problems. Therefore, I'd say, your problem must be caused by other factors or a combination of factors, including any processing of the custom XML part performed by the VSTO add-in that was mentioned in a comment.
