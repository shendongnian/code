        [Route("All")]
        public ActionResult All()
        {
            return PartialView("_StatusFilter",MyAPI.Status.GetAllStatuses());
        }
