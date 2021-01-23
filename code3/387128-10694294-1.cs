        [HttpPost]
        [ValidateInput(false)]
        public ActionResult GoTruckGo(FormCollection oColl)
        {
            try
            {
                 string sender = Request.Unvalidated().Form["sender"];
                 string body =   Request.Unvalidated().Form["body-plain"];
                 sendLog(body);
                 // do something with data 
             }
            catch (Exception ex)
            {
                sendLog("entered catch = "+ ex.Message);
            }
 
            return Content("ok");
        }
