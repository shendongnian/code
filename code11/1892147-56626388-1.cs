        public virtual JsonResult Create(MyCustomModel model)
        {
            try
            {
                ValidationViewModel msg = new ValidationViewModel();
             
                return Json(new { success = msg.Result, message = msg.Message }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
