    [HttpPost("v1/item/{id}/images")]
    public async Task<ActionResult> UploadImage([FromRoute]string Id)
    {
        IFormFile file = Request.Form.Files[0]
        //Upload image logic
    }
