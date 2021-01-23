    private JToken processJsonString(string data, int failPosition)
            {
                string json = "";
                var doubleQuote = "\"";
                try
                {
                    var jsonChars = data.ToCharArray();
                    if (jsonChars[failPosition - 1].ToString().Equals(doubleQuote))
                    {
                        jsonChars[failPosition - 1] = ' ';
                    }
                    json = new string(jsonChars);
                    return JToken.Parse(json);
                }
                catch(JsonReaderException jsonException)
                {
                    return this.processJsonString(json, jsonException.LinePosition);
                }               
            }
