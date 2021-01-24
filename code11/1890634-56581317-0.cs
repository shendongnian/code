    public List<Log> ViewItFilterUseCount()
            {
                var ndtms2Utils = new NDTMS2UtilsEntities();
    
                var logQuery = (from logs in ndtms2Utils.Logs
                    where logs.Message.Contains("ViewIt - View Data")
                    select logs).ToArray();
    
                int index = 0;
                return (from log in logQuery
                    where log.Message.StartsWith("ViewIt - View Data")
                    group log by (index++ / 4) into grp
                    let log = grp.Last()
                    select new Log
                    {
                        Id = log.Id,
                        Date = log.Date,
                        Thread = log.Thread,
                        Level = log.Level,
                        Logger = log.Logger,
                        Message = "ViewIt - View Data - the user has selected: " + string.Join(", ", grp.Select((l) => l.Message.Substring(l.Message.IndexOf(": ") + 2))),
                        Exception = log.Exception
                    }).ToList();
            }
