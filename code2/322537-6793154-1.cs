    public ActionResult LookUpStudentId(string id)
    {
        if(!IsStudentExists(id))
        {
            return new RedirectResult("~/Error/NotFound");
        }
        return View();
    }
