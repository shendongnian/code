    public JsonResult GetSongs()
    {
        var songs = _music.GetSongs(0, 3);
        return Json(new { songs = songs }, JsonRequestBehavior.AllowGet);
    }
    public ActionResult GetSongs()
    {
        var result = GetSongs();
        return Json(new
        {
            // The JsonResult contains additional route data and view data. 
            // Your view is most likely interested in the Data prop (new { songs = songs })
            // depending on how RenderPartialViewToString is written you could also pass ViewData
            PartialViewHtml = RenderPartialViewToString("MyView", result.Data),
            success = true
        }, JsonRequestBehavior.AllowGet);
    }
