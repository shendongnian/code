    public ActionResult GetAll()
        {
            using (var ctx = new MyDbEntities())
            {
                ViewData["Products"] = ctx.Products;
                return View();
            }
        }
