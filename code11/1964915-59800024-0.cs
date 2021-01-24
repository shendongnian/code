    public async Task<IActionResult> Get([FromRoute] string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            return BadRequest($"{nameof(id)} parameter should not be empty");
        if (!long.TryParse(id, out var longValue))
            return BadRequest($"{nameof(id)} should be convertible to long");
        var result = await Mediator.Send(new GetIssueByIdQuery(longValue));
        return CreateResponse(result);
    }
    
