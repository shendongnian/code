    [HttpGet]
    public async Task<IActionResult> GetAllRecords([FromQuery] [CanBeNull] SearchQueryDto request)
    {
        var query = Request.QueryString.HasValue;
        if (query)
        {
            return Ok(await _service.Search(request));
        }
        return Ok(await _service.GetAll());
    }
