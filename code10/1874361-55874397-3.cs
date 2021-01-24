     public HttpStatusCodeResult Create(Product product)
     {
        return Try(()=> {
            _productService.Create(product);
        }, ModelState);
     }
