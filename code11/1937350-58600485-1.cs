    [HttpGet("{source}")]
    public ActionResult<IEnumerable<string>> Get(
        string source, 
        [FromQuery] string year, 
        [FromQuery] string genre) {
    
        if(string.IsNullOrEmpty(year) && string.IsNullOrEmpty(genre))
            return BadRequest();
    
        //...
    }
