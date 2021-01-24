    [HttpGet("find")]
    [ProducesResponseType(typeof(PagableResults<UserDetails>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation("FindUsers")]
    public async Task<IActionResult> FindUsers([FromQuery]SearchFilterContainer searchFilters)
