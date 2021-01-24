  public ActionResult Details(Int id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        List<SingleView> singleView = db.SingleViews.count > 0 ?
                                 db.SingleViews.where(a => a.id == id).tolist() : null ;
        if (singleView == null)
        {
            return HttpNotFound();
        }
        return View(singleView);
    }
