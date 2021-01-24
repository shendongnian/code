    HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://studioden.uk/wpjson/wp/v2/events/");
    if (response.IsSuccessStatusCode)
     {
         var content = await response.Content.ReadAsStringAsync ();
         var events = JsonConvert.DeserializeObject<List<Event>>(content);
     }
