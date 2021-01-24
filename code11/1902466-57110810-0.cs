    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();
        var json = JObject.Parse(content);
        var items = json["value"].Where(i =>  (string)i["@odata.type"] == null);
        var members = items.Select(item => item.ToObject<Microsoft.Graph.User>());
                  
        foreach (var member in members)
        {
              Console.WriteLine(member.UserPrincipalName);                     
        }
    }
 
