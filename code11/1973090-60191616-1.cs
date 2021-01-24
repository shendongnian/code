            IMongoDatabase db = MongoDBDataLayer.NewConnection();
            IMongoCollection<Click> collection = db.GetCollection<Click>("click");
            var unwindOption = new AggregateUnwindOptions<ClickUnwinded>() { PreserveNullAndEmptyArrays = true };
            var result = collection.Aggregate().Unwind<Click, ClickUnwinded>(c => c.Events, unwindOption)
                .Group(
                //group by
                c => new GroupByClass()
                {
                    CampaignId = c.CampaignId,
                    IsTest = c.IsTest,
                    EventId = c.Events.EventId,
                    IsRobot = c.UserAgent.IsRobot
                },
                r => new GroupResultClass()
                {
                    CampaignId = r.First().CampaignId,
                    IsTest = r.First().IsTest,
                    EventId = r.First().Events.EventId,
                    IsRobot = r.First().UserAgent.IsRobot,
                    Count = r.Count()
                }
                ).ToList();
If anyone has an example of how to uttilize facet using c# driver that would be great.
edit - 
So, the problem is that doing the approach above will count the same document multiple times if the document have multiple events ... so I have to either find a way to multi aggregate (first aggregate must happen before the unwind) or to make 2 trips to the db.
