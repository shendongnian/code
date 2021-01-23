    [HttpPost]
    public ActionResult UpdateUser(UserInformation model){
        if (!UserIsAuthorized())
            return new HttpStatusCodeResult(401, "Custom Error Message 1"); // Unauthorized
        if (!model.IsValid)
            return new HttpStatusCodeResult(400, "Custom Error Message 2"); // Bad Request
        // etc.
    }
