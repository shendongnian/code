 c#
public static EventList GetEvents()
{
    /// ...
    XmlSerializer serializer = new XmlSerializer(typeof(EventList));
    // ...
    EventList list = (EventList)serializer.Deserialize(stringReader);
    return list;
}
or alternatively, return a `List<Event>`:
 c#
public static List<Event> GetEvents()
{
    /// ...
    XmlSerializer serializer = new XmlSerializer(typeof(EventList));
    // ...
    EventList list = (EventList)serializer.Deserialize(stringReader);
    return list.Event;
}
Also, to avoid some overhead:
 c#
using (WebResponse webResponse = webRequest.GetResponse())
using (Stream stream = webResponse.GetResponseStream())
using (var reader = XmlReader.Create(stream))
{
    XmlSerializer serializer = new XmlSerializer(typeof(EventList));
    EventList list = (EventList)serializer.Deserialize(reader);
    return list;
}
