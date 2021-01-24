            string tablename = "AnyTableName"; //table whose data you want to fetch
			var BatchRead = ABCContext.Context.CreateBatchGet<ABCTable>(  
                new DynamoDBOperationConfig
                {
                    OverrideTableName = tablename; 
                });
            foreach(string Id in IdList) // in case you are taking string from input
            {
                Guid objGuid = Guid.Parse(Id); //parsing string to guid
                BatchRead.AddKey(objGuid);
            }
            await BatchRead.ExecuteAsync();
            var result = BatchRead.Results;
