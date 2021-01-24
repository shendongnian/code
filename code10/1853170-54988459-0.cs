    private static DocumentClient _documentClient = new DocumentClient(new Uri(serviceEndpoint), key);
    [FunctionName(nameof(MyFunction))]
    public static async Task RunAsync([CosmosDBTrigger(
        databaseName: "MyDatabase",
        collectionName: "MyCollection",
        ConnectionStringSetting = "MyDbConnectionString",
        LeaseCollectionName = "leases",
        CreateLeaseCollectionIfNotExists = true,
        LeaseCollectionPrefix = nameof(MyFunction))]IReadOnlyList<Document> input,
        ILogger log)
    {
        var replacementsTasks = new List<Task>();
        foreach (var item in input)
        {
            if (!item.GetPropertyValue<bool>("Updated")) {
                item.SetPropertyValue("Updated", true);
                replacementsTasks.Add(_documentClient.ReplaceDocumentAsync(item));
            }
        }
        await Task.WhenAll(replacementsTasks);
    }
