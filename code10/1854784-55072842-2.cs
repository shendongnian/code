    [HttpGet]
        [OpenAction]
        public async Task<ActionResult> GetInitialWeight(int sid)
        {
           var initialWeight = await Manager.FindInitialFilterWeightBySID(sid);
           
            return Json(new { initialWeight.MeanWeight }, JsonRequestBehavior.AllowGet);
        }
