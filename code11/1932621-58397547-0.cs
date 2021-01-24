     public RedirectToActionResult RecallRecord(int Mail_Id)
        {           
            {
                using (var ctx = new BrochureDbContext())
                {
                    var reloadSet = ctx.Reload.FromSql($"usp_OAK_Brochure_Reload {Mail_Id}")
                                              .ToList();
                    return RedirectToAction("ReloadOrders");
                }
            }
        }
