     public static IEnumerable<string> CompareJson(JObject json, JObject json2, string path)
        {
            List<string> result = new List<string>();
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
                    result.AddRange(CompareJson(JArray.Parse(property.Value.ToString()), JArray.Parse(itemTokenTwo.ToString()), (!string.IsNullOrWhiteSpace(path)? path + ".":default) + property.Path));
                    continue;
                }
                if (property.Value.Type == JTokenType.Object && itemTokenTwo.Type == JTokenType.Object)
                {
                    result.AddRange(CompareJson(JObject.Parse(property.Value.ToString()), JObject.Parse(itemTokenTwo.ToString()), (!string.IsNullOrWhiteSpace(path) ? path + "." : default) + property.Path));
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
