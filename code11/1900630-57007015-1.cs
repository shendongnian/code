    var result = "{ \"Fruits\":[{\"Number\":\"111\", \"Name\":\"Apple\"}, {\"Number\":\"112\", \"Name\":\"Orange\"},{\"Number\":\"113\", \"Name\":\"Peach\"}]}";
    Dictionary<string, dynamic> data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(result);
    var customTokens = new Dictionary<string, List<string>>();
    foreach (var dataField in data)
    {
        if (dataField.Value is JArray)
        {         
            foreach (JObject content in dataField.Value.Children<JObject>())
            {
                foreach (JProperty prop in content.Properties())
                {
                    if(customTokens.ContainsKey(prop.Name))
                    {
                        customTokens[prop.Name].Add(prop.Value.ToString());
                    }
                    else
                    {
                        customTokens.Add(prop.Name, new List<string> { prop.Value.ToString() });
                    }
                }
            }
            foreach(var item in customTokens)
            {
                Console.WriteLine(item.Key + ":" + String.Join(",", item.Value));
            }
        }
    }
