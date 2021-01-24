csharp
private static void GenerateByCopying()
{
    using (var doc = WordprocessingDocument.Open(DestinationDoc, true))
    using (var appendedDoc = WordprocessingDocument.Open(AppendedDoc, true))
    {
        var body = doc.MainDocumentPart.Document.Body;
        var appendedBody = appendedDoc.MainDocumentPart.Document.Body;
        AppendNecessaryText(body);
        foreach (var part in appendedBody.Elements())
        {
            var clonedElement = part.CloneNode(true);
            clonedElement.Descendants<DocumentFormat.OpenXml.Drawing.Blip>()
                .ToList()
                .ForEach(imageData =>
                {
                    var newRelation = CopyImage(doc, imageData.Embed, appendedDoc);
                    imageData.Embed = newRelation;
                });
            clonedElement.Descendants<DocumentFormat.OpenXml.Vml.ImageData>()
                .ToList()
                .ForEach(imageData =>
                {
                    var newRelation = CopyImage(doc, imageData.RelationshipId, appendedDoc);
                    imageData.RelationshipId = newRelation;
                });
            body.Append(clonedElement);
        }
        doc.MainDocumentPart.Document.Save();
    }
}
public static string CopyImage(WordprocessingDocument doc, string relId, WordprocessingDocument source)
{
    var p = source.MainDocumentPart.GetPartById(relId) as ImagePart;
    var np = doc.MainDocumentPart.AddPart(p);
    np.FeedData(p.GetStream());
    return doc.MainDocumentPart.GetIdOfPart(np);
}
Adjusting the console app run this method after `File.Copy()`, I'm indeed able to open the document with the image and save changes.
