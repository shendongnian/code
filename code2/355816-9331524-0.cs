    private List<ItemGroup> ParseItemGroupList(string input)
        {
            JObject json = JObject.Parse(input);
    
            List<ItemGroup> groups = new List<ItemGroup>();
            JArray gArray = json["groups"] as JArray;
            foreach (var gToken in gArray)
            {
                ItemGroup newGroup = new ItemGroup();
                JToken attrToken = gToken["attributes"] as JToken;
                if (attrToken is JArray)
                {
                    newGroup.Items = attrToken.Children().Select(MapDetailItem()).ToList();
                }
                else
                {
                    newGroup.Items = new List<DetailItem>() { MapDetailItem().Invoke(attrToken) };
                }
    
                groups.Add(newGroup);
            }
    
            return groups;
        }
    
        private static Func<JToken, DetailItem> MapDetailItem()
        {
            return json => new DetailItem
            {
                SortOrder = (string)json["sortOrder"],
                Value = (string)json["value"]
            };
        }
