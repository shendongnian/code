C#
private static readonly SemaphoreSlim Mutex = new SemaphoreSlim(1);
protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
{
  // some logic on request like isUserGranted etc.
  await Mutex.WaitAsync();
  try
  {
    var response = await base.SendAsync(request, cancellationToken);
    return buildApiResponse(request, response);
  }
  finally
  {
    Mutex.Release();
  }
}
