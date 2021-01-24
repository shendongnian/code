var tokenJson = jsonSerializer.Serialise(new {token = tokenString });
using(var client = new HttpClient())
{
  var req = new HttpRequestMessage
  {
      Method = HttpMethod.Get,
      RequestUri = new Uri("some url"),
      Content = new StringContent(tokenJson, Encoding.UTF8, ContentType.Json),
  };
   var res = await client.SendAsync(req).ConfigureAwait(false);
   res.EnsureSuccessStatusCode();
   var res = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
}
