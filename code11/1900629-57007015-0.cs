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
