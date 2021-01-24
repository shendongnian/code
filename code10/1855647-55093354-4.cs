     public async Task<IActionResult> index()
     {
      var productList=   await ProductRepository.GetAllProducts() 
      var ProductModels =  Mapper.Map<IEnumerable<Products>, IEnumerable<ProductsModel>>( productList)
        return View(ProductModels);
     }
