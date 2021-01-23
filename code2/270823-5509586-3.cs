    [HttpPost]
    public ActionResult Edit(int id, TownRecord tr, FormCollection collection)
    {
        tr.RecordTypeId = Int32.Parse(collection["RecordType"]);
        _ctx.TownRecords.Attach(tr);
        _ctx.Entry(tr).State = EntityState.Modified;
        _ctx.SaveChanges();
        return RedirectToAction("List");
    }
