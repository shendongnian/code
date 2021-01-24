  public ActionResult Details(Int id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        List<SingleView> singleView = db.SingleViews.where(a => a.id == id).tolist();
        if (singleView == null)
        {
            return HttpNotFound();
        }
        return View(singleView);
    }
