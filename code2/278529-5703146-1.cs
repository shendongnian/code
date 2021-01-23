    [HttpPost]
    public ActionResult Edit(TableA formdata)
    {
        if (ModelState.IsValid)
        {
            TableA temp = myDB.TableA.First(a=>a.Id == formdata.Id);
            if (TryUpdateModel<TableA>(temp))
            {
                myDB.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        return View();
    }
