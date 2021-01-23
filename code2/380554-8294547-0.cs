    public ActionResult Catalog(string id, int?page)
        {
            Category catalog = pe.Categories.Where(cat => cat.Name == id).Single();
            int pageIndex = page ?? 1;
            CatProView catProView = new CatProView
                                    {
                                        Name = catalog.Name,
                                        SubCategories = catalog.SubCategories,
                                        PagedProducts = catalog.Products.ToPagedList(pageIndex, PageSize)
                                    };
            return View(catProView);
        }
