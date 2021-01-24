    [HttpGet]
    [Route("{numberOfResults:int}")]
    [ResponseType(typeof(IEnumerable<Catalogue>))]
    public IHttpActionResult List(int numberOfResults, bool active = true) => //assuming active default
        Ok(_catalogueService.List(active, numberOfResults));
