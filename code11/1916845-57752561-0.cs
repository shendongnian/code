    public IActionResult PostNewLanguages([FromBody] List<JObject> newLanguages, string id)
    {
        foreach(var obj in newLanguages)
        {
        }
          
        return Ok();
    }
