C#
public sealed class ErrorTypeException : Exception
{
  public ErrorType ErrorType { get; set; }
  ...
}
Then you can model `Succeed` / `Failed` callbacks as a single `Task<string>`:
C#
public async Task<string> ExecuteAsync()
{
  if (isExecuting) return;
  isExecuting = true;
  cancellationTokenSource = new CancellationTokenSource();
  try
  {
    httpResponseMessage = await httpService.SendAsync(requestData, cancellationTokenSource.Token).ConfigureAwait(false);
    var responseString = string.Empty;
    if (httpResponseMessage.Content != null)
    {
      responseString = await httpResponseMessage.Content.ReadAsStringAsync().ConfigureAwait(false);
    }
    if (httpResponseMessage.IsSuccessStatusCode)
      return responseString;
    throw new ErrorTypeException(httpResponseMessage.GetErrorType(),
        $"{httpResponseMessage.ReasonPhrase}\n{responseString}");
  }
  catch(...){
    throw ...
  }
  finally
  {
    Dispose();
  }
}
Usage:
C#
public Task<User> GetUserAsync()
{
  var executor = new HttpExecutor(new RequestData());
  var text = await executor.ExecuteAsync();
  return ParseUser(text);
}
