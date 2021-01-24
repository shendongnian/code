    [HttpGet("GetText")]
    public async Task<IActionResult> GetText()
    {
        try
        {
            string welCome = "Test";    
            return Ok(new { message = welCome });
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
