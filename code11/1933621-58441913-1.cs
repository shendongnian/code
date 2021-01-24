    [HttpPost]
    [Route("/api/add")]
    public ActionResult<Dictionary<string, object>> Add([FromBody]int number)
    {
    
        // number is always 0 :(  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
    
        number += 1;
    
        var d = new Dictionary<string, object>
        {
            ["message"] = "Hello",
            ["number"] = number 
        };
    
        return Ok(d);
    }
