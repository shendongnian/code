async Task myPosterAsync(Payload item)
{
    try
    {
        var doc = await _cosmosDbRepository.GetItemByKeyAsync(GetId(item.SessionId, item.Key), 
                                                          item.SessionId) 
                         ?? new Document();
        doc.SetPropertyValue("_partitionKey", item.SessionId);
        doc.SetPropertyValue("key", GetId(sessionId, item.Key));
        doc.SetPropertyValue("name", item.Name);
        doc.SetPropertyValue("value", item.Value);
        doc.TimeToLive = item.TTL;
        await _cosmosDbRepository.UpsertDocumentAsync(doc, "_partitionKey");
    catch (Exception ex)   
    {
        //Handle the error in some way, eg log it
        ApplicationInsightsLogger.TrackException(ex, new Dictionary<string, string>
        {
            { "sessionID", item.SessionId },
            { "action", "TryStoreItems" }
        });
    }
}
