 [HttpPost]
    public ActionResult CreateOrEdit(int? id, Request request)
    {
        if (id == null)
            {
                try
                {
                    using (DbModels dbModel = new DbModels())
                    {
                        dbModel.Requests.Add(request);
                        dbModel.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                try
                {
                    // Ketu shtojme logjiken e update-imit
                    using (DbModels dbModel = new DbModels())
                    {
                        dbModel.Entry(request).State = System.Data.EntityState.Modified;
                        dbModel.SaveChanges();
                    }
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
        return View();
    }**strong text**
