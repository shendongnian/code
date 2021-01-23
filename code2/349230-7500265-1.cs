    public override object ReadJson(JsonReader reader,
                                    Type objectType,
                                    object existingValue,
                                    JsonSerializer serializer)
    {
        var outer = new Outer()
        while (reader.TokenType != JsonToken.EndObject)
        {
            if (reader.TokenType == JsonToken.PropertyName)
            {
                var propertyName = reader.Value.ToString();
                reader.Read();
                switch (propertyName)
                {
                    case "id":
                        outer.Id = serializer.Deserialize<String>(reader);
                        break;
                    case "id":
                        outer.Properties = serializer.Deserialize<Dictionary<String,String>>(reader);
                        break;
                    case "inner_object"
                        var inner = serializer.Deserialize<Inner>(reader);
                        outer.InnerObjectId = inner.Id;
                        break;
                    [...more cases...]
                    default:
                        serializer.Deserialize<object>(reader);
                        break;
                    }
                    reader.Read(); // consume tokens in reader
                }
            } else {
                // throw exception ?
            }
        }
        return outer;
    }
