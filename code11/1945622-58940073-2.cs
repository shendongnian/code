    [HttpGet]
    public virtual async Task<IActionResult> List([FromQuery] string filter)
    {
        var query = _context.Set<TEntity>();
         
        query = Filter(query, filter);
            
        var result = await query.ToListAsync();
        return Ok(result);
    }    
