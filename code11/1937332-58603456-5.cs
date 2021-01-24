    public static ClientModel ToClientModel(this Model model)
    {
        return new ClientModel
        {
            Id = model.Id.ToString(),
            Value = model.Value
        };
    }
    var clientModel = dbContext.Models
        .Where(model => model.Id = someId)
        .Select(model => model.ToClientModel())
        .ToList();
