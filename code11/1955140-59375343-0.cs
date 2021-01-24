    [HttpPost]
    [Route("api/customer/createCustomer")]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    public async Task<IActionResult> Example([FromBody]CustomerDto customer)
    {
    	//do smth
    	return Created();
    }
