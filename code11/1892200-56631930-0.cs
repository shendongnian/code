C#
public async Task<LoadedJockey> ScrapSingleJockeyPlAsync(int index)
{
    await Task.Run(() =>
    {
        //do some time consuming things
    });
}
The lambda passed to `Task.Run` is not `async`, so the service method cannot possibly be awaited. And indeed [it is not][1].
A better solution would be to load the HTML asynchronously (e.g., using `HttpClient.GetStringAsync`), and then call `HtmlDocument.LoadHtml`, something like this:
C#
public async Task<LoadedJockey> ScrapSingleJockeyPlAsync(int index)
{
  LoadedJockey jockey = new LoadedJockey();
  ...
  string link = sb.ToString();
  var html = await httpClient.GetStringAsync(link).ConfigureAwait(false);
  HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
  doc.LoadHtml(html);
  if (jockey.Name == null)
  ...
  return jockey;
}
And also remove the `Task.Run` from your `for` loop:
C#
private async Task ScrapJockey(string dataType)
{
  LoadedJockey jockey = new LoadedJockey();
  CancellationToken.ThrowIfCancellationRequested();
  if (dataType == "jockeysPl") jockey = await _scrapServices.ScrapSingleJockeyPlAsync(j).ConfigureAwait(false);
  if (dataType == "jockeysCz") jockey = await _scrapServices.ScrapSingleJockeyCzAsync(j).ConfigureAwait(false);
  //doing some stuff with results in here
}
public async Task ScrapJockeys(int startIndex, int stopIndex, string dataType)
{
  //init values and controls in here
  List<Task> tasks = new List<Task>();
  for (int i = startIndex; i < stopIndex; i++)
  {
    tasks.Add(ScrapJockey(dataType));
  }
  try
  {
    await Task.WhenAll(tasks);
  }
  catch (OperationCanceledException)
  {
    //
  }
  finally
  {
    await _dataServices.SaveAllJockeysAsync(Jockeys.ToList()); //saves everything to JSON file
    //soing some stuff with UI props in here
  }
}
  [1]: https://github.com/przemyslawbak/Horse_Picker/blob/190f4549375c9e499c393dc2f3b734a0b802dd8a/Horse_Picker/DataServices/ScrapDataServices.cs#L586
