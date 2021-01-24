    return JsonConvert.SerializeObject(new
    {
        query = new
        {
            @bool = new
            {
                must = new[]
                {
                    new
                    {
                        term = new Dictionary<string, object>
                        {
                            ["firstname.keyword"] = string.Empty,
                        }
                    }
                }
            }
        }
    });
