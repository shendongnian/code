    public JsonResult GetDesignsForProduct(int productId)
    {
      // Instantiate our context and do whatever goo we need to select the objects we want
      using (MyDatabaseContext ctx = new MyDatabaseContext())
      {
         return Json(ctx.Designs.Where(d => d.master_id == productId).ToList(), JsonRequestBehavior.AllowGet);
      }
    }
    public JsonResult GetModelsForDesign(int designId)
    {
      // Instantiate our context and do whatever goo we need to select the objects we want
      using (MyDatabaseContext ctx = new MyDatabaseContext())
      {
         return Json(ctx.Models.Where(d => d.design_id == designId).ToList(), JsonRequestBehavior.AllowGet);
      }
    }
