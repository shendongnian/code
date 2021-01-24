        public ActionResult GetProducts(string sidx, string sord, int page, int rows)
    {
      var products = Product.GetSampleProducts();
      int pageIndex = Convert.ToInt32(page) - 1;
      int pageSize = rows;
      int totalRecords = products.Count();
      int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);
                
      var data = products.OrderBy(x => x.Id)
                    .Skip(pageSize * (page - 1))
                    .Take(pageSize).ToList();
    
      var jsonData = new
      {
          total = totalPages,
          page = page,
          records = totalRecords,
          rows = data
      };
    
      return Json(jsonData, JsonRequestBehavior.AllowGet);
    }
