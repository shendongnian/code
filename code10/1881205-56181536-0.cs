    private async Task AddCustomers()
    {
        try
        {
            foreach (var result in await GetHTMLAsync("https://pastebin.com/raw/gG540TEj"))
            {
                Customers.Add(result.ToString());
            }
         }
         catch (Exception e)
         {
             Debug.WriteLine(e);
             throw;
         }
    }
