    [HttpPost]
    [Route("/api/add")]
    public IActionResult Add([FromBody]Data model) {
    
        if(ModelState.IsValid) {
            
            var number = model.number;
            number += 1;
        
            var d = new {
                message = "Hello",
                number = number 
            };
    
            return Ok(d);
        }
    
        return BadRequest(ModelState);
    }
