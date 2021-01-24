    var result = new MainModel
    {
        value = mainModel.value.Select(x => new ValueModel
        {
            name = x.name,
            Results = x.Results.Select(JsonConvert.DeserializeObject<ResultModel>).ToList()
        }).ToList()
    };
