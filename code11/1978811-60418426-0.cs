    public async Task<IActionResult> Update(string id, ...) 
    {
        if (ValidateId(id) is { } invalid)
            return invalid;
        ...
    }
