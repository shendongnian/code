    [AuthLog(Roles = "Super Admin")]
    [HttpPost]
    public ActionResult ModifyUser(string id)
    {
        string newRole = Request.Form["Roles"];
        string userId = Request.Form["user.UserId"];
        // ...
    }
