c#
public Dictionary<ContentType, long> ToPageResultsMap(AggregateDictionary searchAggregations)
{
    var pageResultsMap = new Dictionary<ContentType, long>();
    var buckets = searchAggregations.Terms(DataConsts.SearchContentTypeDocFieldName).Buckets;
    foreach (var item in buckets)
    {
        if(int.TryParse(item.Key, out int contentType))
        {
            pageResultsMap.Add((ContentType)contentType, item.DocCount.HasValue ? item.DocCount.Value : 0);
        }
    }
  
    return pageResultsMap;
}
