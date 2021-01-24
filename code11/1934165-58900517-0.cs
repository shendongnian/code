csharp
public void AddMultiLineTextToRichTextContentControlsUsingRuns()
{
    // Produce the list of lines from the text separated by "\r\n"
    // in the question, trimming leading and trailing whitespace.
    const string text = "Welcome to Yazd With its winding lanes, forest of badgirs,\r\n mud-brick houses and delightful places to stay, Yazd is a 'don't miss' destination. On a flat plain ringed by mountains, \r\nthe city is wedged between the northern Dasht-e Kavir and southern Dasht-e Lut and is every inch a city of the desert.";
    string[] separator = { "\r\n" };
    List<string> lines = text
        .Split(separator, StringSplitOptions.None)
        .Select(line => line.Trim())
        .ToList();
    // Get the w:document element.
    const string path = @"path\to\your\document.docx";
    using WordprocessingDocument wordDocument = WordprocessingDocument.Open(path, true);
    Document document = wordDocument.MainDocumentPart.Document;
    // Get all Rich Text (i.e., block) w:sdt elements having a w:alias
    // descendant with w:val="Body".
    IEnumerable<SdtBlock> sdts = document
        .Descendants<SdtBlock>()
        .Where(sdt => sdt.Descendants<SdtAlias>().Any(alias => alias.Val == "Body"));
    foreach (SdtBlock sdt in sdts)
    {
        // Create one w:r element per line, prepending a w:br to the
        // second and following runs.
        IEnumerable<Run> runs = lines
            .Select((line, index) =>
                index == 0
                    ? new Run(new Text(line))
                    : new Run(new Break(), new Text(line)));
        // Create or replace the w:sdtContent element with one that has
        // a single w:p with one or more w:r children.
        sdt.SdtContentBlock = new SdtContentBlock(new Paragraph(runs));
    }
}
