     public ActionResult ProductDetail()
        {
            using (var db = new NorthwindEntities())
            {
                return View(db.Products.ToList());
            }
        }
