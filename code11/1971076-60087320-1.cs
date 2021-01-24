    [HttpGet]
    public async Task<IActionResult> GetProductsDetail(int id)
    {
        // Get all the products and then filter by id
        // change "a.Id" to the actual DTO Id property name if different
        var product = (await ProductsService.GetProducts()).FirstOrDefault(a => a.Id == id);
        if (product != null) {
           // If we found something, return that single ProductDTO
           return Json(product);
        } else {
           // Not Found or whatever you want
           return NotFound();
        }
    }
