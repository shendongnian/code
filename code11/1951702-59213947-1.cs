    public async Task<IActionResult> GetMehod([FromQuery] Filter anyName)
    {
        var result = await _service.GetApproved(anyName.Filter);
    
        if (result.Count() == 0)
            return NoContent();
            return Ok(result);
    }
