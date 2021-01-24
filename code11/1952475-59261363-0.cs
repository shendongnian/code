        [HttpPost]
        public ActionResult GetState(string txtAds, string txtRg)
        {
            stateTxtAds = txtAds;
            stateTxtRg = txtRg;
            return View();
        }
