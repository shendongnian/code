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
