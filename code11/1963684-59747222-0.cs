c#
try
{
  using (WebClient client = new WebClient())
  {
    client.Encoding = Encoding.UTF8;
    return await client.DownloadStringTaskAsync(API);
  }
}
catch (NullRefrenceException ex)
{
   Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
  Console.WriteLine(ex.Message);
  return null;
}
