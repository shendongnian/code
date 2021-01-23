    [HttpPost]
    [ValidateInput(false)]
    [ValidateAntiForgeryToken]
    public ActionResult Add(ProductAddModel productAddModel)
    {
      if (ModelState.IsValid)
      {
          Product product = Mapper.Map<ProductAddModel, Product>(productAddModel);
          productRepository.Add(product);
      }
      return RedirectToAction("Index");
    }
