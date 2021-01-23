    public StaticContent : Controller
    {
      public ActionResult Pages(string id)
      {
        return View(id);
      }
    }
