    [RawBody]
    [HttpPatch("{id}")]
    public IActionResult Patch(Guid id, [FromBody] SimpleJsonPatchDocument<Foo> patch)
    {
       var item = Get(id);
       patch.ApplyTo(item);
    
       var json = JObject.Parse((string)Request.HttpContext.Items["Body"]);
    
       return Ok(item);
    }
