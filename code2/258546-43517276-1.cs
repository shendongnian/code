    [HttpPost]
            public ActionResult Index(HttpPostedFileBase[] files)
            {
                foreach (HttpPostedFileBase file in files)
                {
                    if (file != null && file.ContentLength > 0)
                        try
                        {
                            string path = Path.Combine(Server.MapPath("~/Files"), Path.GetFileName(file.FileName));
                            file.SaveAs(path);
                            ViewBag.Message = "File uploaded successfully";
                        }
                        catch (Exception ex)
                        {
                            ViewBag.Message = "ERROR:" + ex.Message.ToString();
                        }
    
                    else
                    {
                        ViewBag.Message = "You have not specified a file.";
                    }
                }
                return View();
            }
