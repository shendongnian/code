    [Route("AddTicket")]
    [HttpPost]
    [Authorize(Roles = MethodsAuthorization.AllRoles)]
    public async Task<IActionResult> AddTicket([FromForm]Model _model)
    {
    
        //code logic here
    
    }
