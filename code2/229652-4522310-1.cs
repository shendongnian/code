    UserDataContext db = new UserDataContext();
    [HttpPost]
    public ViewResult Edit(int userID, FormCollection collection) 
    {
        var user = db.Users.SingleOrDefault(o => o.ID == userID);
        // make sure user or collection isn't null.
        if (!TryUpdateModel(user, collection)) 
        {
            ViewBag.UpdateError = "Update Failure";
            return View("Details", um);
        }
        db.SubmitChanges();
        return View("Details", um); 
    }
