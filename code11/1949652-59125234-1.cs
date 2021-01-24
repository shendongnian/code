public static void Save(string fileName, Event e)
{
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Event));
    using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
    {
        xmlSerializer.Serialize(stream, e);
    }
}
Example of loading the `Event` object from XML (desalinizing):
public static Event Load(string fileName)
{
    Event e = null;
    XmlSerializer xmlSerializer = new XmlSerializer(typeof(Event));
    using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read,  FileShare.None))
    {
        e = (Event)xmlSerializer.Deserialize(stream);
    }
    return e;
}
The XML that will be created for an `Event` object similar (or identical) to what you have in the file:
<?xml version="1.0"?>
<Event xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <id>1</id>
  <title>AA</title>
  <Start>2019-12-01T14:13:58.863</Start>
  <End>2019-12-01T15:13:58.787</End>
  <contacts>
    <Contact>
      <Id>1</Id>
      <Name>ABC</Name>
    </Contact>
    <Contact>
      <Id>2</Id>
      <Name>ABCD</Name>
    </Contact>
    <Contact>
      <Id>3</Id>
      <Name>ABCDE</Name>
    </Contact>
  </contacts>
</Event>
