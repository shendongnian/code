    public IActionResult CallerAction1()
        {
            string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
            string requestPath = Request.Path.ToString();
            return RedirectToAction("CalledAction",new { path = requestPath, name = actionName });
           
        }
        public IActionResult CalledAction()
        {
            var fromPath = HttpContext.Request.Query["path"].ToString();
            var fromActionName= HttpContext.Request.Query["name"].ToString();
           
            // Who called me? Who redirected to me? 1 or 2?
            return View();
        }
