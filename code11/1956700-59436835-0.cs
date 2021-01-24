csharp
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Xunit;
namespace CodeSnippets.Tests.OpenXml.Wordprocessing
{
    public class SimplisticTextReplacementTests
    {
        private const string ToReplace = "to-replace";
        private const string ReplaceWith = "replace-with";
        private static MemoryStream CreateWordprocessingDocument()
        {
            var stream = new MemoryStream();
            const WordprocessingDocumentType type = WordprocessingDocumentType.Document;
            using WordprocessingDocument wordDocument = WordprocessingDocument.Create(stream, type);
            MainDocumentPart mainDocumentPart = wordDocument.AddMainDocumentPart();
            mainDocumentPart.Document =
                new Document(
                    new Body(
                        new Paragraph(
                            new Run(
                                new Text(ToReplace))),
                        new Paragraph(
                            new Run(
                                new Text("to-")),
                            new Run(
                                new Text("replace")))));
            return stream;
        }
        private static void ReplaceText(MemoryStream stream)
        {
            using WordprocessingDocument doc = WordprocessingDocument.Open(stream, true);
            Body body = doc.MainDocumentPart.Document.Body;
            IEnumerable<Paragraph> paras = body.Elements<Paragraph>();
            foreach (Paragraph para in paras)
            {
                foreach (Run run in para.Elements<Run>())
                {
                    foreach (Text text in run.Elements<Text>())
                    {
                        if (text.Text.Contains(ToReplace))
                        {
                            text.Text = text.Text.Replace(ToReplace, ReplaceWith);
                            run.AppendChild(new Break());
                        }
                    }
                }
            }
        }
        [Fact]
        public void SimplisticTextReplacementOnlyWorksInSimpleCases()
        {
            // Arrange.
            using MemoryStream stream = CreateWordprocessingDocument();
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(stream, false))
            {
                Document document = wordDocument.MainDocumentPart.Document;
                Paragraph firstParagraph = document.Descendants<Paragraph>().First();
                Assert.Equal(ToReplace, firstParagraph.InnerText);
                Assert.Contains(firstParagraph.Descendants<Text>(), t => t.Text == ToReplace);
                Paragraph lastParagraph = document.Descendants<Paragraph>().Last();
                Assert.Equal(ToReplace, lastParagraph.InnerText);
                Assert.DoesNotContain(lastParagraph.Descendants<Text>(), t => t.Text == ToReplace);
            }
            // Act.
            ReplaceText(stream);
            // Assert.
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(stream, false))
            {
                Document document = wordDocument.MainDocumentPart.Document;
                Paragraph firstParagraph = document.Descendants<Paragraph>().First();
                Assert.Equal(ReplaceWith, firstParagraph.InnerText);
                Assert.Contains(firstParagraph.Descendants<Text>(), t => t.Text == ReplaceWith);
                Paragraph lastParagraph = document.Descendants<Paragraph>().Last();
                Assert.NotEqual(ReplaceWith, lastParagraph.InnerText);
                Assert.DoesNotContain(lastParagraph.Descendants<Text>(), t => t.Text == ReplaceWith);
            }
        }
    }
}
