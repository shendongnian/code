	[HttpGet]
	public async Task<ActionResult<ICollection<tbl_Product>>> GetProductList()
	{
		return Ok(await _context.tbl_Product.Include(a => a.tbl_ProductPricing).ToListAsync());
	}
	
	
