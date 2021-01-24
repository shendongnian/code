    [HttpGet("GetAllItems")]
    public async Task<IActionResult> GetAllItems()
    {
        return this.Ok(await _storeContext.Table.AsQueryable().ToListAsync());
    }
