    HttpResponseMessage response = await client.GetAsync("https://bungie.net/common/destiny2_content/json/en/DestinyActivityDefinition-7ab91c74-e8a4-40c7-9f70-16a4354125c0.json");
    if (response.IsSuccessStatusCode)
    {
       try
       {
           dynamic content = response.Content.ReadAsAsync<ExpandoObject>().Result;                   
           foreach (dynamic activity in content)
           {
               var dict = ((IDictionary<String, object>)activity.displayProperties)
               //check if .name field exists under displayProperties
               bool exist = dict.ContainsKey("name");
               if (exist == false)
               {
               //do nothing
               }
               else
               {
               //add both Key and displayProperties.name to list
                   bungieActivities.Add(new AllBungieActivities() { ActivityHash = activity.Key, ActivityDescription = activity.displayProperties.name });
               }                        
            }  
         }
         catch
         {
           throw new ArgumentException("The member could not be found.");
         }
      }
