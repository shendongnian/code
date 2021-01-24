    public static IEnumerable<string> CompareJson(JArray json, JArray json2, string path)
        {
            List<string> result = new List<string>();
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
                    result.AddRange(CompareJson(JObject.Parse(jToken.ToString()), JObject.Parse(jToken2.ToString()), path + jToken.Path ));
                    continue;
                }
                if (jToken is JArray && jToken2 is JArray)
                {
                    result.AddRange(CompareJson(JArray.Parse(jToken.ToString()), JArray.Parse(jToken2.ToString()), path + jToken.Path));
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
