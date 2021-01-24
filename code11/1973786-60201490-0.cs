        public ActionResult DisplayInfo(string myInfo)
        {
            MapInfoViewModel info = new MapInfoViewModel()
            {
                Place = myInfo
            };
            return Json(info,JsonRequestBehavior.AllowGet);
        }
