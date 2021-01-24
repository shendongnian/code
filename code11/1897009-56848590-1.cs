    [HttpPost]
        public JsonResult AddApi(string value)
        {
            try
            {
               
                return Json("OK");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
