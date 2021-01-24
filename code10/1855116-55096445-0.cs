        public ActionResult Index()
        {
            ViewBag.PrincipalName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            ViewBag.Name = User.Identity.Name;
            return View();
        }
