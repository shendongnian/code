    //POST api/values
    [HttpPost]
    public IActionResul Post([FromBody]MyClass value) {
        if(ModelState.IsValid) {
            //...
            return Ok();
        }
        return BadRequest();
    }
