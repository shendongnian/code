    [HttpGet]
    public async Task<ActionResult<IEnumerable<ThingVm>>> GetThings()
    {
      var output = await Context.Things
        .Select(e => new ThingVm(e))
        .ToListAsync();
    	
      return Ok(output);
    }
