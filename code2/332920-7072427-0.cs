    public ActionResult Browse(string tName)
            {
                using (TShopEntities db=new TShopEntities())
                {
                    var typeModel = from s in db.Type
                                    select Shirts;
                    return View(typeModel.ToList());
                }
            }
