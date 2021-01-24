    [HttpPost]
    public async Task<IActionResult> Index([FromBody] JsonElement body)
    {
        string json = System.Text.Json.JsonSerializer.Serialize(body);
        return Ok();
    }
