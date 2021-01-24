    //POST api/values
    [HttpPost]
    public IActionResult Post([FromBody]MyClass value) {
        if(ModelState.IsValid) {
            //...
            return Ok();
        }
        return BadRequest();
    }
