    [HttpPost]
    public ActionResult LoginForm(string name, string password)
    {
        SysUser user = model.SysUsers.Where(x => x.SysUserName == name).First();
        {
            if (user != null && user.SysPassword == password)
            {
                Session["usrn"] = name;
                return RedirectToAction("LoginSuccessful", "Users");
            }
            else
            {
                ViewBag.LoginError = true;
            }
        }
    }
