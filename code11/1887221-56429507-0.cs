    public IHttpActionResult GetAll() {
        var products = _context.Products;
    
        if (products == null)
            return NotFound();
        var convertToListFirst = products.Select(x => CreateDto(x)).ToList();
        return Ok(convertToListFirst);
    }
