      public ActionResult Index()
        {
            ViewBag.Message = Session["Sample"];            
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult AddSessionVariable()
        {
            Session["Sample"] = "Sample session variable";
            return RedirectToAction("Index");
        }
        public ActionResult CreateFile()
        {
            var bmp = new Bitmap(100, 100);            
            bmp.Save(Server.MapPath(string.Format(@"\Images\{0}", DateTime.Now.Ticks)));
            return RedirectToAction("Index");
        }
