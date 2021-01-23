    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Add(HttpPostedFileBase httpPostedFileBase)
    {
        using (System.Drawing.Image image = System.Drawing.Image.FromStream(httpPostedFileBase.InputStream, true, true))
        {
            if (image.Width == 100 && image.Height == 100)
            {
                var file = @"D:\test.jpg";
                image.Save(file);
            }
        }
    
        return View();
    }
