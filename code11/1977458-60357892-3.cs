    [HttpPost]
    public IActionResult MyFunction([FromBody]MyModel model) {
        if(ModelState.IsValid) {
            string namex = model.namex;
            return Ok();
        }
        return BadRequest(ModelState);
    }
