    using Newtonsoft.Json;
    string tableName = "Trading.DataSources.Prices2017";
    var tableType = Type.GetType(tableName);
    var results = DbContext.Set(tableType);
    Price newResults = JsonConvert.DeserializeObject<tableType>(JsonConvert.SerializeObject(results));
