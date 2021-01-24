    [HttpGet]
    [Route("blog/{slug}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Blog>> Get(string slug) {
        Blog model = await Task.Run(() => Data.GetBlog(slug));
        if (model == null) {
            return NotFound();
        }
        return model;    
    }
