    [Route("Profile/Skills")]
    public IActionResult Skills()
    {
        if (Request.IsAjaxRequest())
            return PartialView("Skills");
        else
            return View();
    }
