        [HttpPost]
        public ActionResult Login(LoginViewModel mdl)
        {
            // TODO: Do basic auth here first, then send to Host for additional validation
            // Create and send message to the Host
            var message = new LoginMessage { Input = mdl, Result = new LoginResult() };
            MvcContrib.Bus.Send(message);
            if (message.Result.Success)
            {
                // Redirect to defaultUrl set in the Host's web.config
                FormsAuthentication.RedirectFromLoginPage(mdl.Username, false);
            }
            return View("Login", "_Layout", mdl);
        }
