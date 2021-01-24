     IMongoCollection<LogRecord> myCollection = MongoClient.GetDatabase("DatabaseName").GetCollection<LogRecord>("CollectionName");
        List<GroupedData> logSats = myCollection.Aggregate<LogRecord>()
                            .Group<LogRecord, StatsKeys, GroupedData>(
                            t => new StatsKeys
                            {
                                RecordDate= t.RecordDate.ToString("%Y-%m-%d"),
                                Type = t.Type,
                                User = t.UserName
                            },
                            g => new GroupedData
                            {
        
                                count = g.Count(),
                                Success = g.Count(t => !t.Error),
                                Erros = g.Count(t => t.Error),
                                Key = g.Key,
                                AvgTime = g.Average(t => t.FirstStepTime + t.SecondStepTime)
                            }
                            ).ToList();
