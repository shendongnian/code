    [HttpGet("GetText")]
    public async Task<IActionResult> GetText()
    {
        try
        {
            string welCome = "Test";
            JsonSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
    
            return Json(new { message = welCome } , JsonSettings);
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
