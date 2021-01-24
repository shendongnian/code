var strings = new[]
{
    @"\\networkAdd",
    @"\\networkAdd\users",
    @"\\networkAdd\users\test1\",
    @"\\networkAdd\users\test1\delete unicode character test",
    @"\\networkAdd\users\test1\delete unicode character test\character test 1",
    @"\\networkAdd\users\test1\delete unicode character test\character test 1\linked to folder",
    @"\\networkAdd\users\test1\delete unicode character test\character test 2",
    @"\\networkAdd\users\test1\delete unicode character test\character test 3",
    @"http:\\sp2013",
    @"http:\\sp2013\newTestsite",
    @"http:\\sp2013\newTestlib",
    @"http:\\sp2013\newTestlib\sampleFolder",
};
// Obviously, stream it out to a file rather than an in-memory string
using (var stringWriter = new StringWriter())
using (var writer = new XmlTextWriter(stringWriter))
{
    writer.WriteStartDocument();
    writer.WriteStartElement("Items");
    var previous = Array.Empty<string>();
    foreach (var str in strings)
    {
        var current = str.Split('\\', StringSplitOptions.RemoveEmptyEntries);
        int i;
        // Find where the first difference from the previous element is
        for (i = 0; i < Math.Min(current.Length, previous.Length); i++)
        {
            if (current[i] != previous[i])
            {
                break;
            }
        }
        // i now contains the index of the first difference
        // First, close off anything in previous which isn't in the current
        for (int j = i; j < previous.Length; j++)
        {
            writer.WriteEndElement();
        }
        // Then, any new elements
        for (int j = i; j < current.Length; j++)
        {
            writer.WriteStartElement("Item");
            writer.WriteAttributeString("value", current[j]);
        }
        previous = current;
    }
    writer.WriteEndDocument();
}
Gives:
<?xml version="1.0" encoding="utf-16"?>
<Items>
    <Item value="networkAdd">
        <Item value="users">
            <Item value="test1">
                <Item value="delete unicode character test">
                    <Item value="character test 1">
                        <Item value="linked to folder" />
                    </Item>
                    <Item value="character test 2" />
                    <Item value="character test 3" />
                </Item>
            </Item>
        </Item>
    </Item>
    <Item value="http:">
        <Item value="sp2013">
            <Item value="newTestsite" />
            <Item value="newTestlib">
                <Item value="sampleFolder" />
            </Item>
        </Item>
    </Item>
</Items>
It needs a bit of work around handling `://` etc, but the basic principle should be sound.
