     public static async Task<int> GetZendeskOrgID(string CompanyID )
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", "YMUZlOFhS");
                var response = await client.GetAsync("https://zendesk.com/api/v2/organizations/search.json?external_id=" + CompanyID);
                 return response.oganization_id;
            }
        }
      
