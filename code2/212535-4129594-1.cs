        public object Index()
        {
            var user = new UserInfo
                                   {
                                       Name = "Frankie",
                                       Culture = Application.GetSessionCulture(ControllerContext)
                                   };
            try
            {
                Thread.CurrentThread.CurrentCulture = 
                    CultureInfo.CreateSpecificCulture(user.Culture);
            }
            catch
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            }
            Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            ViewData["user"] = user;
            return View();
        }
