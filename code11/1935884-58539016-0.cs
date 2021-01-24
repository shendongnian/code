using Newtonsoft.Json.Linq;
foreach (Document singleDocument in await query.ExecuteNextAsync<Document>())
{
    string artNo = singleDocument.GetPropertyValue<JObject>("OriginalData")["artno"]?.ToString();
    // some other code...
}
