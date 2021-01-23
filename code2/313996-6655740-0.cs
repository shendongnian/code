    var props = new EventLogPropertySelector(new string[] { 
                    "Event/System/TimeCreated/@SystemTime",
                    "Event/EventData/Data[@Name='SubjectDomainName']",
                    "Event/EventData/Data[@Name='SubjectUserName']",
                    "Event/EventData/Data[@Name='ObjectName']",
                    "Event/EventData/Data[@Name='OldSd']",
                    "Event/EventData/Data[@Name='NewSd']",
                    "Event/EventData/Data[@Name='ProcessName']"  });
    
    using (var session = new System.Diagnostics.Eventing.Reader.EventLogSession())
    {
        //4670 == Permissions on an object were changed
        var q = new EventLogQuery("Security", PathType.LogName, "*[System[(EventID=4670)]]");
        q.Session = session;
    
        EventLogReader rdr = new EventLogReader(q);
        
        for (EventRecord eventInstance = rdr.ReadEvent();
                null != eventInstance; eventInstance = rdr.ReadEvent())
        {
            var elr = ((EventLogRecord)eventInstance);
            Console.WriteLine(
                "{0}: '{1}\\{2}' changed security descriptor on file '{3}' from \n'{4}' \nto \n'{5}' \nusing '{6}'\n----\n", 
                elr.GetPropertyValues(props).ToArray());
        }
    }
    
