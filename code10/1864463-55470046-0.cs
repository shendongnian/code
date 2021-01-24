    // POST: api/Authors
    [HttpPost]
    [ResponseType(typeof(Author))]
    public async Task<IHttpActionResult> PostAuthor([FromBody] Author author)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
    
        // etc.
    }
