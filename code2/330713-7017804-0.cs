        [HttpGet]
        public JsonResult Comet(string message)
        {
            MiniProfiler.Stop(true);
            var currentMessage = GetCurrentMessage();
            while (message == currentMessage)
            {
                Thread.Sleep(250);
                currentMessage = GetCurrentMessage();
            }
            return Json(currentMessage, JsonRequestBehavior.AllowGet);
        }
