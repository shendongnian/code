    class DateQueryParameters {
      [Required]
      [Range(2000, int.MaxValue)]
      public int Year {get;set;}
      [Required]
      [Range(1, 12)]
      public int Month {get;set;}
    }
    
    [HttpGet]
    public async Task<IActionResult> GetItemsForMonth([FromQuery] DateQueryParameters dateParameters)
    {
        if(!this.ModelState.IsValid){
           return Task.FromResult(this.BadRequest(this.ModelState));
        }
    }
