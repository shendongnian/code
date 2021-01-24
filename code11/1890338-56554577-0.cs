interface IHaveLineItems
{
    void AddLineItem(object item);
}
This can then be implemented on the various `Header` classes, e.g.
public class Header : IHaveLineItems
{
    public string Id { get; set; }
    public string Description { get; set; }
    public List<Item> LineItems { get; set; }
    void IHaveLineItems.AddLineItem(object item)
    {
        LineItems.Add((Item)item);
    }
}
Your loop could then become:
var data = new List<H>();
IHaveLineItems lastHeader = null;
var lineIndex = 1;
foreach (string line in File.ReadAllLines(fileNamePath))
{
    // read HDR line
    if (line.StartsWith("HDR"))
    {
        var header = ReadHeaderLine<H>(uploadConfig, line, errMsg);
        data.Add(header);
        lastHeader = header;
    }
    // read LIN line
    if (line.StartsWith("LIN"))
    {
        var lineItem = ReadItemLine<I>(uploadConfig, line, errMsg);
        lastHeader.AddLineItem(lineItem);
    }
    lineIndex += 1;
}
