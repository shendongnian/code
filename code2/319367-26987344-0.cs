    [OutputCache(Duration = 60, Location = System.Web.UI.OutputCacheLocation.Client, VaryByParam = "random")]
    [CompressFilter]
    public ActionResult Page(PageModel model)
    {
          ...
    }
