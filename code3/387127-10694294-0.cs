            [ValidateInput(false)]
        [HttpPost]
        public ActionResult GoTruckGo(FormCollection oColl)
        {
            try
            {
                 string sender = Request["sender"];
                 string body = Request["body-plain"];
                 // do something with data 
             }
            catch (Exception ex)
            {
                sendLog("entered catch = "+ ex.Message);
            }
 
            return Content("ok");
        }
