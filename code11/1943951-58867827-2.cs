    public class WorldPayResponseModel
    {
        public string CardType { get; set; } 
        public int CardId { get; set; } 
        // other properties
        ...
    }
    
    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public IActionResult Residential([FromForm] WorldPayResponseModel model)
    {
        if (model == null || !ModelState.IsValid) return BadRequest("No data was present");    
    
        // ----- removed from brevity ----- //
    
        return Ok(true);
    }
