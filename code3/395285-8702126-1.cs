    [HttpPost]
    public ActionResult UpdateUser(UserInformation model){
        if (!UserIsAuthorized())
            return new HttpStatusCodeResult(401); // Unauthorized
        if (!model.IsValid)
            return new HttpStatusCodeResult(400); // Bad Request
        // etc.
    }
