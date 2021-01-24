    [HttpPost]
    [Route("SendAsync")]
    public async Task<IActionResult> SendAsync([FromBody]EmailModel model) {
        if(ModelState.IsValid) {
            IEmain email = new EmailMessage();
            //...code here to map model to the desired type
    
            await this._emailService.SendAsync(email);
            return Ok();
        }
        return BadRequest(ModelState);
    }
