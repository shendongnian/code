xml
    <w:p>
        <w:r>
            <w:t>Date of birth: October 15</w:t>
        </w:r>
        <w:r>
            <w:rPr>
                <w:vertAlign w:val="superscript"/>
            </w:rPr>
            <w:t>th</w:t>
        </w:r>
        <w:r>
            <w:t>, 2019</w:t>
        </w:r>
    </w:p>
Note the second `w:r` element (`Run` class) with its `w:rPr` child (`RunProperties` class) and `w:vertAlign` grandchild (`VerticalTextAlignment` class), which formats the "th" as superscript.
Using the Open XML SDK, you would create the above paragraph as follows (noting that the indentation matches so you see the correspondence):
csharp
var paragraph =
    new Paragraph(
        new Run(
            new Text("Date of birth: October 15")),
        new Run(
            new RunProperties(
                new VerticalTextAlignment { Val = VerticalPositionValues.Superscript }),
            new Text("th")),
        new Run(
            new Text(", 2019")));
### Update 2019-11-25:
If you want to format existing text as shown above, you'll have to identify and format the ordinal number suffices "st", "nd", "rd", and "th". The `Paragraph FormatSuperscript(string innerText)` method does that. It uses the `Text CreateText(string text)` method to produce a `w:text` element with the correct `xml:space` attribute for whatever text (i.e., without leading or trailing whitespace) you want to render.
csharp
// Matches ordinal number suffixes "st", "nd", "rd", and "th".
private static readonly Regex OrdinalNumberSuffixRegex =
    new Regex("(?<=[0-9]+)(st|nd|rd|th)");
/// <summary>
/// Creates a new <see cref="Paragraph" /> with ordinal number suffixes
/// (i.e., "st", "nd", "rd", and "4th") formatted as a superscript.
/// </summary>
/// <param name="innerText">The paragraph's inner text.</param>
/// <returns>A new, formatted <see cref="Paragraph" />.</returns>
public static Paragraph FormatSuperscript(string innerText)
{
    var destParagraph = new Paragraph();
    var startIndex = 0;
    foreach (Match match in OrdinalNumberSuffixRegex.Matches(innerText))
    {
        if (match.Index > startIndex)
        {
            string text = innerText[startIndex..match.Index];
            destParagraph.AppendChild(new Run(CreateText(text)));
        }
        destParagraph.AppendChild(
            new Run(
                new RunProperties(
                    new VerticalTextAlignment
                    {
                        Val = VerticalPositionValues.Superscript
                    }),
                CreateText(match.Value)));
        startIndex = match.Index + match.Length;
    }
    if (startIndex < innerText.Length)
    {
        string text = innerText.Substring(startIndex);
        destParagraph.AppendChild(new Run(CreateText(text)));
    }
    return destParagraph;
}
/// <summary>
/// Creates a new <see cref="Text" /> instance with the correct xml:space
/// attribute value.
/// </summary>
/// <param name="text">The text.</param>
/// <returns>A new <see cref="Text" /> instance.</returns>
public static Text CreateText(string text)
{
    if (string.IsNullOrEmpty(text))
    {
        return new Text();
    }
    if (char.IsWhiteSpace(text[0]) || char.IsWhiteSpace(text[^1]))
    {
        return new Text(text) { Space = SpaceProcessingModeValues.Preserve };
    }
    return new Text(text);
}
The following unit test shows how to use the `FormatSuperscript()` method from above:
csharp
[Fact]
public void FormatSuperscript_DateOfBirth_CorrectlyFormatted()
{
    // Say we have a body or other container with a number of paragraphs, one
    // of which is the paragraph that we want to format. In our case, we want
    // the paragraph the inner text of which starts with "Date of birth:"
    var body =
        new Body(
            new Paragraph(new Run(new Text("Full name: Phung Anh Tu"))),
            new Paragraph(new Run(new Text("Date of birth: October 15th, 2019"))),
            new Paragraph(new Run(new Text("Gender: male"))));
    Paragraph sourceParagraph = body
        .Descendants<Paragraph>()
        .First(p => p.InnerText.StartsWith("Date of birth:"));
    // In a first step, we'll create a new, formatted paragraph.
    Paragraph destParagraph = FormatSuperscript(sourceParagraph.InnerText);
    // Next, we format the existing paragraph by replacing it with the new,
    // formatted one.
    body.ReplaceChild(destParagraph, sourceParagraph);
    // Finally, let's verify that we have a single "th" run that is:
    // - preceded by one run with inner text "Date of birth: October 15",
    // - followed by one run with inner text ", 2019", and
    // - formatted as a superscript.
    Assert.Single(body
        .Descendants<Run>()
        .Where(r => r.InnerText == "th" &&
                    r.PreviousSibling().InnerText == "Date of birth: October 15" &&
                    r.NextSibling().InnerText == ", 2019" &&
                    r.RunProperties.VerticalTextAlignment.Val == VerticalPositionValues.Superscript));
}
You'll find the full source code in my [CodeSnippets][1] GitHub repository. Look for the [OrdinalNumberFormattingTests][2] class.
  [1]: https://github.com/ThomasBarnekow/CodeSnippets
  [2]: https://github.com/ThomasBarnekow/CodeSnippets/blob/master/CodeSnippets.Tests/OpenXml/Wordprocessing/OrdinalNumberFormattingTests.cs
