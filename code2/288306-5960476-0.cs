    public ActionResult Invalidate()
    {
        OutputCacheAttribute.ChildActionCache = new MemoryCache("NewDefault");
        return View();
    }
