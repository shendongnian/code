    var deserializedJson = JsonConvert.DeserializeObject<Results>(json);
    var results = deserializedJson
        .Items
        .Select(entry => new Result
        {
            Id = (long)entry.Value["id"],
            Name = (string)entry.Value["name"],
            Cdate = DateTime.TryParse((string)entry.Value["cdate"], out var cdate) ? cdate : DateTime.MinValue,
            Private = (long)entry.Value["private"],
            UserId = (long)entry.Value["userid"],
            SubscriberCount = (long)entry.Value["subscriber_count"]
        });
    Console.WriteLine($"result_code={deserializedJson.ResultCode},result_message={deserializedJson.ResultMessage},result_output={deserializedJson.ResultOutput}");
    foreach (var result in results)
    {
        Console.WriteLine(result.ToString());
    }
