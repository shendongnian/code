    public IActionResult Get(CountryCode model) {
        if (!ModelState.IsValid)
            return BadRequest("list errors");
        //logic here
        return Ok();
    }
