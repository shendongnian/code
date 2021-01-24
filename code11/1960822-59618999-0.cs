private static JsonTokenType GetTokenType(byte[] bytes)
{
    var reader = new Utf8JsonReader(bytes.AsSpan());
    reader.Read();
    return reader.TokenType;
}
var ms = new MemoryStream();
await Request.Body.CopyToAsync(ms);
var jsonBytes = ms.ToArray();
switch (GetTokenType(jsonBytes)) 
{
    case JsonTokenType.StartObject:
        return JsonSerializer.Deserialize<GraphQLRequest>(jsonBytes);
    case JsonTokenType.StartArray:
        return JsonSerializer.Deserialize<GraphQLRequest[]>(jsonBytes);
    default:
        // ...
}
