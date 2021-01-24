        public ActionResult Index()
        {
            //load up your select list into the view bag
            ViewBag.BinOptions = ViewHelper.PopulateBinList();
            //preset the value of your desired object
            var bm = new BinModel { BinId = "582" };
            return View(bm);
        }
