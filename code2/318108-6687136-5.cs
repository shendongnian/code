    [HttpPost]
            [Authorize(Roles = "Administrator, SuperUser")]
            public ActionResult AddTableToTable(VipTableViewModel model, string backButton)
            {
                if (backButton != null)
                {
                    return RedirectToAction("AddTableTo", new { id = model.VipServiceId });
                }
    
                if (ModelState.IsValid)
                {
                    VipService v = db.VipServices.Single(x => x.VipServiceId == model.VipServiceId);
                    Table t = db.Tables.Single(x => x.TableId == model.TableId);
                    v.Tables.Add(t);
    
                    db.SaveChanges();
                    return RedirectToAction("Details", new { id = model.VipServiceId });
                }
    
                else
                {
                    return View(model);
                }
                
            }
