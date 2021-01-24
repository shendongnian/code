    [HttpPost]
    public async Task<IHttpActionResult> Receiving([FromBody]Document documentObject)
    {
         var content = await Request.Content.ReadAsStringAsync();
         return Json(content); // output => "name=xxx&number=123"
    }
