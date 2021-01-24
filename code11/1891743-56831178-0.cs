    public static class JsonHelper
        {
            public static string SerializeToMinimalJson(object obj)
            {
                return JToken.FromObject(obj).RemoveEmptyChildren().ToString();
            }
    
            public static JToken RemoveEmptyChildren(this JToken token)
            {
                if (token.Type == JTokenType.Object)
                {
                    JObject copy = new JObject();
                    foreach (JProperty prop in token.Children<JProperty>())
                    {
                        JToken child = prop.Value;
                        if (child.HasValues)
                        {
                            child = child.RemoveEmptyChildren();
                        }
                        if (!child.IsNullOrEmpty())
                        {
                            copy.Add(prop.Name, child);
                        }
                    }
                    return copy;
                }
                else if (token.Type == JTokenType.Array)
                {
                    JArray copy = new JArray();
                    foreach (JToken item in token.Children())
                    {
                        JToken child = item;
                        if (child.HasValues)
                        {
                            child = child.RemoveEmptyChildren();
                        }
                        if (!child.IsNullOrEmpty())
                        {
                            copy.Add(child);
                        }
                    }
                    return copy;
                }
                return token;
            }
    
            public static bool IsNullOrEmpty(this JToken token)
            {
                return token == null ||
                       (token.Type == JTokenType.Array && !token.HasValues) ||
                       (token.Type == JTokenType.Object && !token.HasValues) ||
                       (token.Type == JTokenType.String && token.ToString() == String.Empty) ||
                       (token.Type == JTokenType.Null);
            }
    
        }
