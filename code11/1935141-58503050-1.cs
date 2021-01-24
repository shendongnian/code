    public IActionResult SomeAction([FromBody] SomeActionModel model) {
        if(ModelState.IsValid) {
            string param1 = model.param1;
            IEnumerable<SomeType> param2 = model.param2;
            IEnumerable<SomeType> param3 = model.param3;
            //...
            return Ok();
        }
        return BadRequest(ModelState);
    }
