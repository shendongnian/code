c#
var resultObject = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(input)
    .SelectMany(key => key.Value.Select(str => new { StrKey = key.Key, Language = str.Key, Value = str.Value }))
    .GroupBy(item => item.Language)
    .ToDictionary(group => group.Key, group => group.ToDictionary(item => item.StrKey, item => item.Value));
var resultStr = JsonConvert.SerializeObject(result, Formatting.Indented);
