    static async Task GetNameFirst(HttpClient client,  string queryNameFirst, List<Properties> results)
    {
        string reportType = "JSON";
    
        foreach (var item in results)
        {
            var output = await client.GetAsync(queryNameFirst + item.ReportID + reportType);
    
            if (output.IsSuccessStatusCode)
            {
                var allText = await output.Content.ReadAsStringAsync();
    
    			var fields = JsonConvert.DeserializeObject<List<NameFirst>>(allText);
    		}
            else
            {
                // Error code returned
                Console.WriteLine("No records found on second method.");
            }
    
        }
    
    }
