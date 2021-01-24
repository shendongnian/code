return AsyncContext.Run(async () =>
{
   var get = await httpClient.GetAsync(url).ConfigureAwait(false);
   if (get.IsSuccessStatusCode && (get.StatusCode == HttpStatusCode.OK))
   {
      var content = await get.Content.ReadAsStringAsync().ConfigureAwait(false);
      return content;
   }
   return "";
});
