    BadRequest(ModelStateDictionary model)
    {
        var newModel = model.ToDictionary(
                x => x.Key.ToCamelCase(),  
                x => kvp.Value
            );
        base.BadRequest(newModel);
    }
