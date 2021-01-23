    [HttpPost]
    public ActionResult Save(Product p)
        {
            ProductRepository rep = new ProductRepository();
            rep.Update(p);
            return RedirectToAction("List");
        }
