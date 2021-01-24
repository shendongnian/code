async Task<List<string> SendTexts(IEnumerable<string> textsToSend)
{
    var results=new List<string>();
    foreach(var text in textsToSend)
    {
        var result=await SendAsync(text);
        results.Add(result);
    }
}
And use it with :
    var results=await SendTexts(texts);
In C# 8 we can return individual results and use them asynchronously. We don't need to cache the results before returning them either :
async IAsyncEmumerable<string> SendTexts(IEnumerable<string> textsToSend)
{
    foreach(var text in textsToSend)
    {
        var result=await SendAsync(text);
        yield return;
    }
}
await foreach(var result in SendTexts(texts))
{
   ...
}
`await foreach` is only needed to *consume* the IAsyncEnumerable result, not produce it
