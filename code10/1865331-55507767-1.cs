    public class Promoter
    {
        public static string ToArray(string json, string propertyPath)
        {
            JToken root = JToken.Parse(json);
            JToken tokenToPromote = root.SelectToken(propertyPath);
            if (tokenToPromote == null)
            {
                throw new JsonException(propertyPath + " was not found");
            }
            if (tokenToPromote.Type == JTokenType.Array)
            {
                return json;  // value is already an array so return the original JSON
            }
            tokenToPromote.Replace(new JArray(tokenToPromote));
            return root.ToString(Formatting.None);
        }
    }
