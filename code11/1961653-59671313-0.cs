using (HttpClient client = new HttpClient())
{
     var html = await client.GetStringAsync(url);
     html = await client.GetStringAsync(url);
     ...
}
