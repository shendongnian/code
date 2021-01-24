    // level = 1 is critical, level = 2 is error, level = 3 is warning and level = 4 is information
                // 86400000 is 1 day in milliseconds
                // 259200000 is 3 days in milliseconds
                // 2592000000 is 30 days in milliseconds
                string queryString = "<QueryList>" +
                "  <Query Id=\"0\" Path=\"System\">" +
                "    <Select Path=\"System\">" +
                "        *[System[(Level=1 or Level=2) and" +
                "        TimeCreated[timediff(@SystemTime) &lt; " + historicalDaysInMilliseconds + "]]]" +
                "    </Select>" +
                "  </Query>" +
                "</QueryList>";
                EventLogSession session = new EventLogSession(server);
                EventLogQuery evtquery = new EventLogQuery("System", PathType.LogName, queryString) { ReverseDirection = true };
                evtquery.Session = session;
                EventLogReader logReader = new EventLogReader(evtquery);
                EventRecord entry;
                List<string> eventArr = new List<string>();
                while ((entry = logReader.ReadEvent()) != null)
                {
                    foreach (string eventId in events)
                    {
                        if (eventId == entry.Id.ToString())
                        {
                            //eventArr.Add(entry.Id.ToString() + " - " + entry.MachineName + " - " + entry.TimeCreated.Value.ToString());
                            Console.WriteLine(entry.Id.ToString() + " - " + entry.MachineName + " - " + entry.TimeCreated.Value.ToString() + " - " + eventArr.Count);
                            returnValue.Add(server + ", " + entry.Id.ToString() + ", " + entry.TimeCreated.Value.ToString());
                            stop = "here";
                        }
                    }
                }
