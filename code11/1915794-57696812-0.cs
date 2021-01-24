    // PUT: api/AnyLists/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAnyList(string id, object anyList, string anyListType)
    {
        var anyListObject = Convert.ChangeType(anyList, Type.GetType(anyListType)));
        if (id != anyListObject.AnyId)
        {
            return BadRequest();
        }
        _context.Entry(anyListObject).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            // Whatever error handling you need
        }
        return NoContent();
    }
