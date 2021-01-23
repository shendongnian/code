    XElement xmlEvents = XElement.Parse(e.Result);
    lstb.ItemsSource =
                from GetEvents in xmlEvents.Descendants("e2event")
                select new GetEvents
                {
                     eventid = GetEvents.Element("eventid").Value,
                     eventtime = ConvertTime(GetEvents.Element("eventtime").Value)
                };
