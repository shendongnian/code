private async IAsyncEnumerable<T> GetList<T>(Uri url, CancellationToken cancellationToken = default)
{
    //Don't cache the entire response
    using var httpResponse = await httpClient.GetAsync(url,                               
                                                       HttpCompletionOption.ResponseHeadersRead,  
                                                       cancellationToken);
    using var stream = await httpResponse.Content.ReadAsStreamAsync();
    using var jsonStreamReader = new Utf8JsonStreamReader(stream, 32 * 1024);
    jsonStreamReader.Read(); // move to array start
    jsonStreamReader.Read(); // move to start of the object
    while (jsonStreamReader.TokenType != JsonTokenType.EndArray)
    {
        //Gracefully return if cancellation is requested.
        //Could be cancellationToken.ThrowIfCancellationRequested()
        if(cancellationToken.IsCancellationRequested)
        {
            return;
        }
        // deserialize object
        var obj = jsonStreamReader.Deserialize<T>();
        yield return obj;
        // JsonSerializer.Deserialize ends on last token of the object parsed,
        // move to the first token of next object
        jsonStreamReader.Read();
    }
}
