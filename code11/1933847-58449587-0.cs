    [HttpGet]
    [Route("/api/v{version:apiVersion}/[controller]/{id}.json")]
    public IActionResult PersonAsJson([FromRoute] int id, [FromQuery] bool pretty = false)
    {
        var person = new Person(id)
        // ...
        Response.Headers.Add("Content-Type", "application/json");
        
        if (pretty)
        {
            return Ok(JsonSerializer.Serialize(
                person,
                new JsonSerializerOptions { WriteIndented = true }));
        }
        // non pretty output if there's no
        // services.AddControllers().AddJsonOptions(
        //    options => options.JsonSerializerOptions.WriteIndented = true);
        // in Startup.cs
        return Ok(person);
    }
