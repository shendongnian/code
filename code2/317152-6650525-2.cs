    string xml = @"<?xml version=""1.0"" ?>
    <Events>
        <Event>
            <Id>542</Id>
            <Times>
                <EventTime>
                    <Time>2011-11-28T14:00:00</Time>
                </EventTime>
                <EventTime>
                    <Time>2011-11-30T10:00:00</Time>
                </EventTime>
                <EventTime>
                    <Time>2011-11-30T09:00:00</Time>
                </EventTime>
            </Times>
        </Event>
    </Events>";
    int eventId = 542;
    foreach (var evt in GetEvents(XDocument.Parse(xml), eventId)
    {
        Console.WriteLine("{0}", evt.EventDate);
    }
