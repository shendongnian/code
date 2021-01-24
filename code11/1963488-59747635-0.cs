    [HttpPost]
    [Route("api/pdf/GenerateAndEmailZipOfPDFs/{lastRefreshDateTime}")]
    public IActionResult Privacy([FromBody]string data,[FromRoute]DateTime lastRefreshDateTime)
    {
        //...
    }
