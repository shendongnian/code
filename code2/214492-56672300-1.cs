    public ActionResult RedirectAction()
    {
        if(TempData["data"] != null)
        {
            HttpCookie dataCookie = new HttpCookie("dataCookie");
            dataCookie.Values.Add("account", TempData["data"] as string);
            dataCookie.Expires = DateTime.Now.AddHours(12);
            Response.Cookies.Add(dataCookie);
        }
        return View();
    }
