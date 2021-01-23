     public ActionResult Validatecall()
     {
            ActionResult result;
            try
            {
              // do whatever
            }
            catch (Exception e)
            {
               result = new JsonResult()
                        {
                            Data = new { success = false, exceptionMsg = e.Message },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
            }
            return result;
    }
