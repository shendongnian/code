    public ActionResult Create()
    {
        Session["returnURL"] = Request.UrlReferrer.AbsoluteUri;
        ...
    }
