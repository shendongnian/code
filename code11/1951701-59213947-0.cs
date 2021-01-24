    public async Task<IActionResult> GetMehod([FromQuery] string filter)
    {
        var result = await _service.GetApproved(filter);
    
    if (result.Count() == 0)
            return NoContent();
            return Ok(result);
    }
