            [HttpPost]
            public ActionResult ReceiveValueWithRequestFormData()
            {
                string userName = Request.Form["txtUserName"]; 
                string password = Request.Form["txtPassword"];
                if (userName.Equals("user", StringComparison.CurrentCultureIgnoreCase)
                && password.Equals("pass", StringComparison.CurrentCultureIgnoreCase))
                {
                    return Content("Login successful !");
                }
                else
                {
                    return Content("Login failed !");
                }
            }
