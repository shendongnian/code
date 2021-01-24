    public async Task<IHttpActionResult> Post() {
        var response = await IsDataValid();
        if (response)
            return Ok();
        return BadRequest();
    }
