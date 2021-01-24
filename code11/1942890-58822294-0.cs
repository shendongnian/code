    private IActionResult GetImsResponse(ImsRequest req)
    {
        var response = service.Process(req);
        if (response is IErrorResponse)
            return BadRequest(((IErrorResponse)response).Message);
        if (response != null)
        {
            if (response.HasImage())
            {
                return File(response.GetImage(), "image/png");
            }
            return Ok(response.GetObjectForRepresentInJson());
        }
        return // return something when response is null
    }
