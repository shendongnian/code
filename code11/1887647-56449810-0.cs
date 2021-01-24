     [Route("~/api/books/{id}")] [HttpGet]
     public IActionResult Get(int id)
    {
        try
        {
            var result= _command2.Execute(id);
            return Ok(result);
        }
        catch(Exception e)
        {
            // Try returning some other exception other than 404.
        }
    }
