    [HttpPost]
    [ValidateInput(false)]
    public ActionResult ResendPassword(EditUserModel model)
    {
        try
        {
            Admin admin = new Admin();
            admin.SendForgottenPasswordToUser(model.UserName);
            return View("EditUser", model);
        }
        catch (Exception ex)
        {
            // Error handling here.
        }
    }
