    public static Dictionary<string, object> DotNotationToDictionary(Dictionary<string, string> dotNotation)
    {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        foreach (var dotObject in dotNotation)
        {
            var hierarcy = dotObject.Key.Split('.');
            Dictionary<string, object> bottom = dictionary;
            for (int i = 0; i < hierarcy.Length; i++)
            {
                var key = hierarcy[i];
                if (i == hierarcy.Length - 1) // Last key
                {
                    bottom.Add(key, dotObject.Value);
                }
                else {
                    if (!bottom.ContainsKey(key))
                        bottom.Add(key, new Dictionary<string, object>());
                    
                    bottom = (Dictionary<string, object>) bottom[key];
                }
            }
        }
        return dictionary;
    }
    
