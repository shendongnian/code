    [HttpGet]
    [Route("exportpowerpoint1")]
    public HttpResponseMessage Export()
    {   
    	var returnResult = Request.CreateResponse(HttpStatusCode.OK);
    	returnResult.Content = new StreamContent(File.OpenRead(HttpContext.Current.Server.MapPath("~/PPTexports/testfile.pptx")));
    	returnResult.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.presentationml.presentation");
    	returnResult.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
    	{
    		FileName = "testfile.pptx"
    	};                
    	return returnResult;
    }
