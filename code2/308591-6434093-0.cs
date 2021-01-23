    public ActionResult Save(SubCategory subcategory)
            {
                if (ModelState.IsValid)
                {
                    if (subcategory.id> 0)
                    {
                        SubCategory orig = db.SubCategory.Single(x => x.ID == subcategory.id);
                        if (TryUpdateModel<SubCategory>(orig))
                        {
                            db.Save();
                        }
                    }
                    else
                    {
                        db.Add(subcategory);
                        db.Save();
                    }
    
                }
    
    
                return View(subcategory);
            }
