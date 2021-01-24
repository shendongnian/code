    public ActionResult Logout()
    {
        if (Request.Cookies["user"] != null)
        {
            var user = new HttpCookie("user")
            {
                Expires = DateTime.Now.AddDays(-1),
                Value = null
            };
            Response.SetCookie(user);
            Response.Cookies.Clear();
        }
        if(Session["UserName"] != null)
        {
            Session["UserName"] = null;
            Session["IsAdmin"] = null;
        }
      //Session.Abandon();
      //Session.Clear();
      return RedirectToAction("Login", "Home");
    }
