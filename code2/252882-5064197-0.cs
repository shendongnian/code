    [HttpPost]
    public ActionResult SaveFile(HttpPostedFileBase file)
    {
        //some file upload magic
        // return JSON
        return Json(new
        {
            name = "picture.jpg",
            type = "image/jpeg",
            size = 123456789
        });
    }
