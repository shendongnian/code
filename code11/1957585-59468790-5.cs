    public static class ExtensionJson
    {
        public static IEnumerable<string> CompareJson(this JObject json, JObject json2, string path)
        {
            var result = new List<string>();
            foreach (var property in json.Properties())
            {
                json2.TryGetValue(property.Name, out var itemTokenTwo);
                if (itemTokenTwo == null)
                {
                    result.Add($"{{ \"fieldName\": {path}{property.Path},\"targetValue\": {property.Value},\"sourceValue\": NULL }}");
                    continue;
                }
                if (property.Value.Type == JTokenType.Array && itemTokenTwo.Type == JTokenType.Array)
                {
                    result.AddRange(JArray.Parse(property.Value.ToString()).CompareJson(JArray.Parse(itemTokenTwo.ToString()),
                        (!string.IsNullOrWhiteSpace(path) ? path + "." : default) + property.Path));
                    continue;
                }
                if (property.Value.Type == JTokenType.Object && itemTokenTwo.Type == JTokenType.Object)
                {
                    result.AddRange(JObject.Parse(property.Value.ToString()).CompareJson(JObject.Parse(itemTokenTwo.ToString()), (!string.IsNullOrWhiteSpace(path) ? path + "." : default) + property.Path));
                    continue;
                }
                if (property.Value.Type != itemTokenTwo.Type)
                {
                    result.Add($"{{ \"fieldName\": {path}{property.Path},\"targetValue\": {property.Value},\"sourceValue\": {itemTokenTwo} }}");
                    continue;
                }
                if (property.Value.ToString() != itemTokenTwo.Value<string>().ToString())
                {
                    result.Add($"{{ \"fieldName\": {path}.{property.Path},\"targetValue\": {property.Value},\"sourceValue\": {itemTokenTwo} }}");
                }
            }
            return result;
        }
        public static IEnumerable<string> CompareJson(this JArray json, JArray json2, string path)
        {
            var result = new List<string>();
            foreach (var jToken in json)
            {
                var jToken2 = json2.SelectToken(jToken.Path);
                if (jToken2 == null)
                {
                    result.Add($"{{ \"fieldName\": {path}{jToken.Path},\"targetValue\": {jToken},\"sourceValue\": NULL }}");
                    continue;
                }
                if (jToken is JObject && jToken2 is JObject)
                {
                    result.AddRange(JObject.Parse(jToken.ToString())
                        .CompareJson(JObject.Parse(jToken2.ToString()), path + jToken.Path));
                    continue;
                }
                if (jToken is JArray && jToken2 is JArray)
                {
                    result.AddRange(JArray.Parse(jToken.ToString()).CompareJson(JArray.Parse(jToken2.ToString()), path + jToken.Path));
                    continue;
                }
                if (jToken is JProperty jProperty && jToken2 is JProperty token2)
                {
                    if (jProperty.Value != token2.Value)
                    {
                        result.Add($"{{ \"fieldName\": {path}{jProperty.Path},\"targetValue\": {jProperty.Value},\"sourceValue\": {jToken2} }}");
                    }
                }
                else if (jToken is JValue value1 && jToken2 is JValue value2)
                {
                    if (!value1.Equals(value2))
                    {
                        result.Add(
                            $"{{ \"fieldName\": {path}{jToken.Path},\"targetValue\": {value1},\"sourceValue\": {value2} }}");
                    }
                }
                else if (jToken is JProperty property)
                {
                    result.Add($"{{ \"fieldName\": {path}{property.Path},\"targetValue\": {property.Value},\"sourceValue\": {jToken2} }}");
                }
                else
                {
                    result.Add($"{{ \"fieldName\": {path}{((JProperty)jToken2).Path},\"targetValue\": {((JProperty)jToken2).Value},\"sourceValue\": {jToken} }}");
                }
            }
            return result;
        }
    }
    
