       public static EventUnit DisplayEventAndLogInformation(string fileToSearch, DateTime actionTime)
            {
                StringBuilder sb = new StringBuilder();
                const string queryString = @"<QueryList>
      <Query Id=""0"" Path=""Security"">
        <Select Path=""Security"">*</Select>
      </Query>
    </QueryList>";
                EventLogQuery eventsQuery = new EventLogQuery("Security", PathType.LogName, queryString);
                eventsQuery.ReverseDirection = true;
                EventLogReader logReader = new EventLogReader(eventsQuery);
                EventUnit e = new EventUnit();
                bool isStop = false;
                for (EventRecord eventInstance = logReader.ReadEvent(); null != eventInstance; eventInstance = logReader.ReadEvent())
                {
                    foreach (var VARIABLE in eventInstance.Properties)
                        if (VARIABLE.Value.ToString().ToLower().Contains(fileToSearch.ToLower()) && actionTime.ToString("d/M/yyyy HH:mm:ss") == eventInstance.TimeCreated.Value.ToString("d/M/yyyy HH:mm:ss"))
                        {
                            foreach (var VARIABLE2 in eventInstance.Properties) sb.AppendLine(VARIABLE2.Value.ToString());
                            e.Message = sb.ToString();
                            e.User = (eventInstance.Properties.Count > 1) ? eventInstance.Properties[1].Value.ToString() : "n/a";
                            e.File = fileToSearch;
                            isStop = true;
                            break;
                        }
                    if (isStop) break;
                    try
                    {
                        //    Console.WriteLine("Description: {0}", eventInstance.FormatDescription());
                    }
                    catch (Exception e2)
                    {
                    }
                }
                return e;
            }
