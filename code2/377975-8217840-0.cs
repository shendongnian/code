     const string queryString = @"<QueryList>  <Query Id=""0"" Path=""Security"">    <Select Path=""Security"">*</Select>  </Query></QueryList>";
    
            EventLogQuery eventsQuery = new EventLogQuery("Security", PathType.LogName, queryString);
            eventsQuery.ReverseDirection = true;
            EventLogReader logReader = new EventLogReader(eventsQuery);
           
            for (EventRecord eventInstance = logReader.ReadEvent();
                null != eventInstance; eventInstance = logReader.ReadEvent())
            {
                foreach (var VARIABLE in  eventInstance.Properties)
                    if (VARIABLE.Value.ToString().ToLower().Contains(...)
                    {
                        ...
                    }
             }
