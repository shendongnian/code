    public async Task<IActionResult> Update(string id, ...) 
    {
        var invalid = ValidateId(id);
        if (invalid != null)
            return invalid;
        ...
    }
