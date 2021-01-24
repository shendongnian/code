`
        static void Main(string[] args)
        {
            EventLogQuery eventsQuery = new EventLogQuery("ForwardedEvents", PathType.LogName);
            try
            {
                EventLogReader logReader = new EventLogReader(eventsQuery);
                for (EventRecord eventdetail = logReader.ReadEvent(); eventdetail != null; eventdetail = logReader.ReadEvent())
                {
                    Console.WriteLine(eventdetail.FormatDescription());
                }
            }
            catch (EventLogNotFoundException e)
            {
                Console.WriteLine("Error while reading the event logs");
            }
            Console.ReadKey();
        }
`
I don't have any forwarded event but it does not fail.
