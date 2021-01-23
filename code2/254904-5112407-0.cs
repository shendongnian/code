    public ActionResult Error()
    {
      return view();
    }
    [HttpPost]
        public ActionResult Index(HttpPostedFileBase excelFile)
        {
            if (excelFile != null)
            {
                *Snip for brevity, everything is peachy here.*
    
                return View();
            }
            else
            {
                return RedirectToAction("Error","Upload");
            }            
        }
