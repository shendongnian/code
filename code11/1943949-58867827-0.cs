    public class TransactionDto
    {
        public string CardType { get; set; } 
        public int CardId { get; set; } 
        // other properties
        ...
    }
    
    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    public IActionResult Residential([FromForm] TransactionDto model)
    {
        if (model == null) return BadRequest("No data was present");    
    
        // ----- removed from brevity ----- //
    
        return Ok(true);
    }
