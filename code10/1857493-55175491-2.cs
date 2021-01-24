    [HttpPost]
    public async Task<IActionResult> createEntity([FromBody]YourDto yourDto)
    {
        try
        {
             // do whatever you want to do with the yourDto object
             return Ok();
        }
        catch (Exception ex)
        {
              return StatusCode(500, "Internal server error");
        }
    }
