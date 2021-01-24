    [HttpPatch("{id}")]
    public async Task<ActionResult> PatchResource([FromRoute][Required] Guid id, 
    [FromBody][Required] PatchRequest request)
    {
        string body;
        using (var reader = new StreamReader(Request.Body))
        {
            body = reader.ReadToEnd();
        }
    
        validator = new ValidationBase();
        string resultValidation = validator.ValidateObject(body, new PatchRequest());
    
        if (resultValidation.Length != 0)
        {
            return BadRequest(new { error_message = resultValidation });
        }
    
        // Content endpoint
    
        return Json(response);
    }
