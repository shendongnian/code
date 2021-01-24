    [AcceptVerbs(HttpVerbs.Post)]
    public JsonResult Login(String username, String password)
    {
        ...
        if (ValidUser)
        {
            FormsAuthentication.SetAuthCookie(username, true);
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        return Json(true, JsonRequestBehavior.AllowGet);
    }
