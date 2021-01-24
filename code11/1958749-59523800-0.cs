    string propertyName = "";
    var isArray = false;
    var arrayHeaderprinted = false;
    var headers = new List<string>();
    var data = new List<string>();
    var arrayData = new List<string>();
    using (var reader = new JsonTextReader(new StringReader(json)))
    {
        while (reader.Read())
        {
            switch (reader.TokenType)
            {
                case JsonToken.PropertyName:
                    propertyName = (string)reader.Value;
                    break;
                case JsonToken.StartArray:
                    isArray = true;
                    break;
                case JsonToken.EndArray:
                case JsonToken.StartObject:
                    isArray = false;
                    if (arrayHeaderprinted)
                    {
                        arrayHeaderprinted = false;
                        data.Add(string.Join("-", arrayData));
                    }
                    break;
                case JsonToken.Null:
                case JsonToken.String:
                case JsonToken.Boolean:
                case JsonToken.Date:
                case JsonToken.Float:
                case JsonToken.Integer:
                    if (isArray)
                    {
                        if (!arrayHeaderprinted)
                        {
                            arrayHeaderprinted = true;
                            headers.Add(propertyName);
                        }
                        arrayData.Add(reader.Value.ToString());
                    }
                    else
                    {
                        headers.Add(propertyName);
                        data.Add(reader.Value?.ToString() ?? "");
                    }
                    break;
            }
        }
    }
    Console.WriteLine(string.Join(",", headers));
    Console.WriteLine(string.Join(",", data));
