public async Task<IEnumerable<CompletePanel>> GetCompleteData(string id params string[] args)
{
    List<QuereyRequest> requests = new List<QuereyRequest>();
    foreach (string argument in args)
    {
        var queryRequest = RequestBuilder(id);
        var result = await queryRequest;
        var knownResult = result.Items.Select(Map2).FirstOrDefaut();
        requests.Add(knownResult);
    }
    return requests;
}
Then in your controller instead of performing a loop you just pass the id and time argument or logical
argument as string to the method.
