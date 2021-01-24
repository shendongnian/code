    public IActionResult MyApiFunction()
    {
     try
     {
        ... do something
     }
     catch(Exception ex)
     {
       ... do some logging
       return BadRequest();
     }
    }
