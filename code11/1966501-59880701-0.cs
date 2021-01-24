    HtmlNode table = doc.DocumentNode.SelectSingleNode("//table//tbody");
    if (table != null)
    {
        foreach (HtmlNode cell in table.SelectNodes(".//tr/td"))
        {
            var nodeWithSpanTag = cell.SelectSingleNode(".//span[2]");
            if (nodeWithSpanTag != null)
                Console.WriteLine(nodeWithSpanTag.InnerText.Trim());
        }
    }
**Output**
    Joker.2019.WEBRip.XviD.MP3-SHITBOX
if i use `//span` (instead of `.//span`), i get the above line printed 5 times.
This example will produce the same result as above,
 Console.WriteLine(doc.DocumentNode.SelectSingleNode("//table//tbody//tr/td//span[2]")?.InnerText.Trim());
