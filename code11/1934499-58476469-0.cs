    [HttpPatch("updateMessageTemplate/{templateId}")]
    public IActionResult UpdateMessageTemplate([FromHeader] int tenantId, int templateId, 
    [FromBody] JsonPatchDocument<testMsg> msg)
     {
     try
     {
        //Some implementation is here
        return Accepted();
     }
     catch
     {
        return StatusCode(500);
     }
    }
