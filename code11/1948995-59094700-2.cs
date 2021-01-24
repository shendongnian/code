    var results = JsonConvert.DeserializeObject<Dictionary<string,Result>>(json);
	var sortedDictionary = results.Select(kvp => new {User=kvp.Key,Result=kvp.Value})
	                              .OrderByDescending(x=>x.Result.Wins)
                                  .ThenBy(x=>x.Result.Loses)
								  .ToDictionary(key=>key.User,
                                              value=>new Result
                                                     { 
                                                         Wins = value.Result.Wins,
                                                         Loses=value.Result.Loses
                                                     }
                                                );
    var sortedJson = JsonConvert.SerializeObject(sortedDictionary);
